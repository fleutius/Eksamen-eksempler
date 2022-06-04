using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Basket
    {

        protected int _baskettotal;
        public int BasketTotal {
            get
            {
                return this._baskettotal;
            }
        }

        public int? CustId { get; set; }

        public List<string> ItemList = new List<string>();

        public int total = 0;
        public virtual void AddItem(string ProductName, int ProductId, int ProductPrice, int Quantity)
        {
            ItemList.Add(ProductName);
            _baskettotal += (ProductPrice * Quantity);
        }

        public void GetItems()
        {
            foreach (var i in ItemList)
            {
                Console.WriteLine(i);
            }
        }
        public virtual void AmountDue()
        {
            GetItems();
            Console.WriteLine("Total amount for Order: " + BasketTotal + " Inc VAT");
        }



    }
    class BusinessBasket:Basket
    {
        public override void AmountDue()
        {
            GetItems();
            Console.WriteLine("Total amount for Order: " + BasketTotal + " Excl. VAT");
        }
    }

    class ConsumerBasket : Basket
    {
        public int Vat { get; set; } = 25;

        static int VatPercentage(int Vat)
        {
            return (Vat / 100) + 1;
        }
        public override void AddItem(string ProductName, int ProductId, int ProductPrice, int Quantity)
        {
            ItemList.Add(ProductName);
            _baskettotal += (ProductPrice * Quantity) + VatPercentage(Vat) ;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Base Basket class
    class Basket
    {

        protected int _baskettotal;
        
        //Getter for _baskettotal. the field has no public setter here, since this is done later 
        public int BasketTotal {
            get
            {
                return this._baskettotal;
            }
        }

        public int? CustId { get; set; }

        public List<string> ItemList = new List<string>();

        public int total = 0;

        //Adds selected items to ItemList and functions as Setter for _baskettotal
        public virtual void AddItem(string ProductName, int ProductId, int ProductPrice, int Quantity)
        {
            ItemList.Add(ProductName);
            _baskettotal += (ProductPrice * Quantity);
        }

        // Loops over items in ItemList and prints them to screen
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
    // BusinessBasket overrides AmountDue in order to show the user that the total is excluding VAT
    class BusinessBasket:Basket
    {
        public override void AmountDue()
        {
            GetItems();
            Console.WriteLine("Total amount for Order: " + BasketTotal + " Excl. VAT");
        }
    }

    //ConsumerBasket overrides AddItem in order to add VAT to the total shown in Main
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

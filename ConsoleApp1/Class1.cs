using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product Prod1 = new Product();
            Prod1.ProductName = "Lim";
            Prod1.ProductId = 1;
            Prod1.ProductPrice = 10;
            
            Product Prod2 = new Product();
            Prod2.ProductName = "Stolpe";
            Prod2.ProductId = 2;
            Prod2.ProductPrice = 20;

            Customer Cust1 = new Customer();
            Cust1.Fname = "Jens";
            Cust1.Email = "jens@jems.dk";
            Cust1.CustID = 0001;

            Customer Cust2 = new Customer();
            Cust2.Fname = "Jysk";
            Cust2.Email = "info@jysk.dk";
            Cust2.CustID = 0002;

            ConsumerBasket Cust1Basket = new ConsumerBasket();
            Cust1Basket.CustId = Cust1.CustID;

            Cust1Basket.AddItem(Prod1.ProductName, Prod1.ProductId, Prod1.ProductPrice, 2);

            Cust1Basket.AddItem(Prod2.ProductName, Prod2.ProductId, Prod2.ProductPrice, 4);

            Console.WriteLine("Showing Basket items and total for " + Cust1.Fname);
            Cust1Basket.AmountDue();

            Console.WriteLine("---------------------------------------------------");

            BusinessBasket Cust2Basket = new BusinessBasket();
            Cust2Basket.CustId = Cust2.CustID;
            Cust2Basket.AddItem(Prod1.ProductName, Prod1.ProductId, Prod1.ProductPrice, 2);

            Cust2Basket.AddItem(Prod2.ProductName, Prod2.ProductId, Prod2.ProductPrice, 4);
            Console.WriteLine("Showing Basket items and total for " + Cust2.Fname);
            Cust2Basket.AmountDue();
            Console.WriteLine("---------------------------------------------------");

        }
    }
}

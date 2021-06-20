using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    class Magazines:Media
    {
        public string Publisher { get; set; }
        public int Pages { get; set; }

        public Magazines(string id, string pName, double price, string pub, int pages) : base(id, pName, price)
        {
            this.Publisher = pub;
            this.Pages = pages;
        }

        public override double Vat()
        {
            double tax = 0;
            if (1 <= Pages && Pages <= 20)
            {
                tax = 0.02*price;
                Console.WriteLine("VAT Price: {0}", tax + price);
                return price + tax;
            }
            if (21 <= Pages && Pages <= 50)
            {
                tax = 0.03 * price;
                Console.WriteLine("VAT Price: {0}", tax + price);
                return price + tax;
            }
            tax = 0.05 * price;
            Console.WriteLine("VAT Price: {0}", tax + price);
            return price + tax;
        }
    }
}

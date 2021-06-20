using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    class Books:Media
    {
        public string author { get; set; }
        public string publisher { get; set; }

        public Books(string id, string pName, double price, string author, string pub) : base(id, pName, price)
        {
            this.author = author;
            this.publisher = pub;
        }

        //calculating VAT
        public override double Vat()
        {
            double tax = 0.1*price;
            double vatPrice = tax+price;
            Console.WriteLine("VAT Price: {0}", vatPrice);
            return vatPrice;
        }
    }
}

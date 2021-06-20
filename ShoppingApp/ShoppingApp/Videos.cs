using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    class Videos:Media
    {
        //should I write duration with string?
        public double Duration { get; set; }
        public int cdNumber { get; set; }

        public Videos(string id, string pName, double price, double d, int cd) : base(id, pName, price)
        {
            this.Duration = d;
            this.cdNumber = cd;
        }

        public override double Vat()
        {
            int d = (int)(Duration / 60);
            double tax = (cdNumber*0.03*price) + (d*0.05*price);
            Console.WriteLine("VAT Price: {0}", tax+price);
            return price + tax;
        }
    }
}

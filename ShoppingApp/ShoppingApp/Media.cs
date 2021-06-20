using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    class Media
    {
        public string productName { get; set; }
        public string id { get; set; }
        public double price { get; set; }

        public Media(string Id, string pName, double Price)
        {
            this.productName = pName;
            this.id = Id;
            this.price = Price;
        }

        //adding the VAT method here:
        public virtual double Vat()
        {
            double tax = 0;
            return price + tax;
        }
    }
}

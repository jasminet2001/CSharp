using System;
using System.IO;

namespace ShoppingApp
{
    class Customer
    {
        public static string Name { get; set; }
        static string _nationalID;
        public static string NationalId
        {
            get { return _nationalID; }
            set
            {
                bool Verify = value.CheckId();
                if (value.Length == 10 && Verify)
                {
                    _nationalID = value;
                }
                else
                {
                    throw new Exception("Wrong ID Format!");
                }
            }
        }

        public Customer(string name, string id)
        {
            Name = name;
            NationalId = id;
        }

        //saving info
        public void SaveData()
        {

            string path = @"D:\AP\Exercise\Six\ShoppingApp\ShoppingApp\CustomersInfo.txt";

            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("Name: {0}", Name);
                    sw.WriteLine("ID: {0}", NationalId);
                }
            }
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Name: {0}", Name);
                    sw.WriteLine("ID: {0}", NationalId);
                }
            }
        }
    }
}

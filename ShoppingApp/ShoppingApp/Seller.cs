using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ShoppingApp
{
    class Seller
    {
        private string _password;
        public string Password { get { return _password; } set { _password = value; } }
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                _username = value;
                Match match = regex.Match(_username);

                if (match.Success)
                {
                    //Console.WriteLine(_username + " is correct");
                    _username = value;
                }

                else
                    throw new Exception("Email format is incorrect");

            }
        }
        static string defaultPass = "MyShop1234$";
        static List<DateTime> dt = new List<DateTime>();

        public Seller(string username, string pass)
        {
            this.Username = username;
            this.Password = pass;
        }

        public Seller(string username)
        {
            this.Username = username;
            this.Password = defaultPass;
        }

        //method for editing products
        public void Edit()
        {
            Console.Write(
                "Add: 1, Delete: 2, Search: 3, Show Customer: 4, Change Password: 5, Exit: 6 => ");
            int choice = int.Parse(Console.ReadLine());

            //creating an intance of library to use its methods
            Library l = new Library();

            //the file that contains cutomers' info
            string CustomerInfo = @"D:\AP\Exercise\Six\ShoppingApp\ShoppingApp\CustomersInfo.txt";

            switch (choice)
            {
                case 1:
                    l.AddMedia();
                    break;

                case 2:
                    l.DelMedia();
                    break;

                case 3:
                    l.SearchMedia();
                    break;

                case 4:
                    if (File.Exists(CustomerInfo))
                    {
                        var lines = File.ReadAllLines(CustomerInfo);
                        foreach (var line in lines)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Customer file does not exist!");
                    }
                    break;

                case 5:
                    ChangePass();
                    break;

                case 6:
                    break;
            }
        }

        //a method for changing password
        public void ChangePass()
        {
            Console.Write("Enter New Password: ");
            string newPass = Console.ReadLine();
            DateTime now = DateTime.Now;

            if (0 < dt.Count)
            {
                Console.WriteLine("Last time the password changed: {0}", dt[dt.Count - 1]);
                defaultPass = newPass;
                Console.WriteLine("Password changes successfully!");
            }
            else
            {
                defaultPass = newPass;
                Console.WriteLine("Password changes successfully!");
            }
            dt.Add(now);
        }
    }
}

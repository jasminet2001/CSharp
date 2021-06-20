using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShoppingApp
{
    class User
    {
        public User() { }

        //method for user menu
        public void UserInfo(string userType)
        {
            bool stop = false;

            while (!stop)
            {
                Console.Write("Select: 1, Edit: 2, Buy:3, Chance:4, Exit: 5 => ");
                int n = int.Parse(Console.ReadLine());

                //the path where the products info exists
                string path = @"D:\AP\Exercise\Six\ShoppingApp\ShoppingApp\LibraryInfo.txt";

                //the path for user's shopping cart
                string cart = @"D:\AP\Exercise\Six\ShoppingApp\ShoppingApp\Cart.txt";

                switch (n)
                {
                    case 1:
                        //below is the number of times the user is allowed to add to the shopping cart
                        int count = 0;
                        if (File.Exists(path) && count < 20)
                        {
                            Library lib = new Library();
                            //printing info of products on the screen
                            var linesInfo = File.ReadAllLines(path);
                            foreach (var line in linesInfo)
                            {
                                Console.WriteLine(line);
                            }

                            //Notice: I saved products' names on products of 2 line numbers instead of 5!
                            string[] info = lib.SearchMediaByName();

                            if (info != null)
                            {
                                SaveData(cart, info);
                            }

                            else
                            {
                                Console.WriteLine("Sorry, it seems we could not find your product!");
                                break;
                            }

                            //calculates the total price with no discount each time
                            CalcPrice(cart, false, userType);

                            count++;
                        }

                        break;

                    case 2:
                        //shows the cart
                        var lines = File.ReadAllLines(cart);
                        foreach (var line in lines)
                        {
                            Console.WriteLine(line);
                        }

                        //deletes the desired product
                        DeleteProduct(cart);
                        break;

                    case 3:
                        CalcPrice(cart, true, userType);
                        break;

                    case 4:
                        //choosing a random number
                        int[] rand = { 0, 2, 3, 5, 7, 10, 15, 25 };
                        Random rnd = new Random();
                        int num = rnd.Next(rand.Length);
                        //why does it always equals zero?
                        double index = num / 100.0;

                        CalcPrice(cart, true, userType, index);
                        break;

                    case 5:
                        stop = true;
                        break;

                }
            }
        }

        //to append data to shopping cart
        public void SaveData(string path, string[] data)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(data[0]);
                sw.WriteLine(data[1]);
                sw.WriteLine(data[2]);
                sw.WriteLine(data[3]);
                sw.WriteLine(data[4]);
            }
        }

        //a method to delete media
        public void DeleteProduct(string path)
        {
            Console.Write("Enter a name to remove: ");
            string name = "Name: " + Console.ReadLine();

            if (name != "Name: ")
            {
                //a temp.txt file to temporarily hold the modified version
                string temp = @"D:\AP\Exercise\Six\ShoppingApp\ShoppingApp\tempCart.txt";
                int lineNum = 0;
                bool exists = false;
                string[] lines = File.ReadAllLines(path);

                //finds the number of the line that has the given id
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(name))
                    {
                        lineNum = i;
                        exists = true;
                        break;
                    }
                }

                //if name exists in the cart do this
                if (exists)
                {
                    using (StreamWriter newSr = new StreamWriter(temp, true))
                    {
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lineNum - 1 <= i && i <= lineNum + 3)
                            {
                                //do nothing
                                continue;
                            }
                            else
                            {
                                //overwrites the old file
                                newSr.WriteLine(lines[i]);
                            }
                        }
                    }

                    //overwrites the file in path
                    if (File.Exists(temp) && File.Exists(path))
                    {
                        var tempLines = File.ReadAllLines(temp);
                        using (StreamWriter newSr = new StreamWriter(path))
                        {
                            for (int i = 0; i < tempLines.Length; i++)
                            {
                                newSr.WriteLine(tempLines[i]);
                            }
                        }
                    }
                    if (!File.Exists(temp))
                    {
                        File.Create(temp).Dispose();
                        File.Copy(temp, path);
                    }

                    //deletes the temp file after using it
                    File.Delete(temp);
                }
                else
                {
                    Console.WriteLine("No such item found in your cart!");
                }
            }

            else
            {
                Console.WriteLine("No name was entered!");
            }
        }

        //a method for calculating price
        //bool buy is for tracking wether the customer finalized their purchase.
        public void CalcPrice(string filePath, bool buy, string profession, double chance = 0)
        {
            double noDiscount = 0;
            double Discount = 0;

            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("Price"))
                {
                    var words = lines[i].Split(' ');
                    noDiscount += int.Parse(words[2]);
                }
            }

            switch (profession)
            {
                case "Teacher":
                    if (15 < lines.Length)
                    {
                        Discount = noDiscount - (noDiscount * .15) - (noDiscount * chance);
                    }
                    else
                    {
                        Discount = noDiscount;
                    }
                    break;

                case "Student":
                    Discount = noDiscount - (noDiscount * .2) - (noDiscount * chance);
                    break;

                case "Customer":
                    //if the number of lines is more than 15(for 3 products)
                    if (25 < lines.Length)
                    {
                        Discount = noDiscount - (noDiscount * .05) - (noDiscount * chance); ;
                    }
                    else
                    {
                        Discount = noDiscount;
                    }
                    break;
            }

            if (buy)
            {
                Console.WriteLine("Total price after Discount: {0}", Discount);
            }
            else
            {
                Console.WriteLine("Total price before Discount: {0}", noDiscount);
            }
        }
    }
}

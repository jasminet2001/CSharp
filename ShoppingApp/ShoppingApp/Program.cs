using System;
using System.Collections.Generic;
using System.IO;

namespace ShoppingApp
{
    class Program
    {
        enum access
        {
            Admin,
            User
        }
        static void Main(string[] args)
        {
            try
            {
                bool stop = false;
                while (!stop)
                {
                    Console.Write("Admin: 0, User: 1, Exit: 2=> ");
                    int inputOne = int.Parse(Console.ReadLine());
                    int user = (int)access.User;
                    int admin = (int)access.Admin;

                    if (inputOne == user)
                    {
                        Console.Write("Enter User's Type (Student, Teacher, Customer): ");
                        string userType = Console.ReadLine();

                        User userInfo = new User();

                        switch (userType)
                        {
                            case "Student":
                                Console.Write("Username: ");
                                string username = Console.ReadLine();
                                Console.Write("Student ID: ");
                                string stdID = Console.ReadLine();
                                Student s = new Student(username, stdID);
                                //saves info of the student in a file
                                s.SaveData();

                                userInfo.UserInfo(userType);
                                break;

                            case "Teacher":
                                Console.Write("Username: ");
                                string name = Console.ReadLine();
                                Console.Write("Institution: ");
                                string inst = Console.ReadLine();
                                Teacher t = new Teacher(name, inst);
                                t.SaveData();

                                userInfo.UserInfo(userType);
                                break;

                            case "Customer":
                                Console.Write("Username: ");
                                string cUsername = Console.ReadLine();
                                Console.Write("National ID: ");
                                string nationalId = Console.ReadLine();
                                Customer c = new Customer(cUsername, nationalId);
                                c.SaveData();

                                userInfo.UserInfo(userType);
                                break;
                        }

                        continue;
                    }
                    if (inputOne == admin)
                    {
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();
                        //should I make an instance of Seller class?
                        if (password == "")
                        {
                            Seller seller = new Seller(email);
                            seller.Edit();
                        }
                        else
                        {
                            Seller seller = new Seller(email, password);
                            seller.Edit();
                        }

                        continue;
                    }
                    if (inputOne == 2)
                    {
                        break;
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public static class ExtensionString
    {
        //extension method
        public static bool CheckId(this string s)
        {
            int a = (int)Char.GetNumericValue(s[9]);
            int b = 0;
            int n = 10;
            for (int i = 0; i < 9; i++)
            {
                int val = (int)Char.GetNumericValue(s[i]);
                b += val * n;
                n--;
            }
            int c = b % 11;

            //verifying id
            int frequency = 0;
            for (int i = 0; i < 9; i++)
            {
                if (s[i] == s[i + 1])
                {
                    frequency++;
                }
            }

            if (frequency == 9)
            {
                //throw new Exception("All the digits are the same!");
                return false;
            }
            if (c == 0 && a == c)
            {
                return true;
            }
            if (1 < c && a == Math.Abs(c - 11))
            {
                return true;
            }
            if (c == 0 && a == c)
            {
                return true;
            }
            else
            {
                //throw new Exception("Wrong ID!");
                return false;
            }
        }

    }
}

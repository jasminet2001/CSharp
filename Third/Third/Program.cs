using System;
using System.Linq;
using System.Collections.Generic;
namespace Third
{
    class Program
    {
        //should I use enums for degrees?
        public static List<Employee> employees = new List<Employee>(100);
        static void Main(string[] args)
        {
            bool stop = false;
            while (!stop)
            {
                string line = Console.ReadLine();
                string[] line1 = line.Split(' ');
                //checks all the non-null array elements to hire people???
                //int result = employees.Count(s => s == null);
                if (line1[0] == "hire:")
                {
                    //checking if the name is lowercase and not repeated
                    if (SmallLetterName(line1[1]) == true && DuplicateName(line1[1]) == false)
                    {
                        string name = line1[1];
                        int degree = int.Parse(line1[2]);
                        Employee NewEmplyee = new Employee(name, degree);
                        hire(NewEmplyee);
                        continue;
                    }
                    else if (SmallLetterName(line1[0]) == false)
                    {
                        Console.WriteLine("Enter a name with lowercase: ");
                        continue;
                    }
                    Console.WriteLine("Duplicate Name! Please Enter Another Name: ");
                    continue;
                }
                if (line1[0] == "pay:")
                {
                    FindPay(line1[1]);
                    continue;
                }
                if (line1[0] == "get:")
                {
                    string name = line1[1];
                    int quantity = int.Parse(line1[2]);
                    ChangeBalance(name, quantity);
                    continue;
                }
                if (line1[0] == "special:")
                {
                    string name = line1[1];
                    Special(name);
                    continue;
                }
                if (line1[0] == "loan:")
                {
                    Loan(line1[1]);
                    continue;
                }
                if (line1[0] == "promote:")
                {
                    Promote();
                    continue;
                }
                if (line1[0] == "regress:")
                {
                    Regress();
                    continue;
                }
                if (line1[0] == "report:")
                {
                    string name = line1[1];
                    Report(name);
                    continue;
                }
                if (line == "End Career")
                {
                    stop = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }

        }
        public static bool SmallLetterName(string Name)
        {
            if (char.IsLower(Name, 0)== true)
            {
                return true;
            }
            return false;
        }
        //how to write this:
        public static bool DuplicateName(string Name)
        {
            foreach (var employee in employees)
            {
                if (!(employee == null) && employee.Name == Name)
                {
                    return true;
                }
            }
            return false;
        }
        public static void FindPay(string name)
        {
            foreach (var employee in employees)
            {
                if (!(employee == null) && employee.Name == name)
                {
                    switch (employee.Degree)
                    {
                        case 1:
                            employee.Balance += 100;
                            break;
                        case 2:
                            employee.Balance += 300;
                            break;
                        case 3:
                            employee.Balance += 700;
                            break;
                        case 4:
                            employee.Balance += 900;
                            break;

                    }
                }
            }
        }
        public static void hire(Employee e)
        {
            employees.Add(e);
        }
        public static void ChangeBalance(string name, int quantity)
        {
            foreach (var employee in employees)
            {
                if (employee.Name==name && quantity<=employee.Balance)
                {
                    employee.Balance -= quantity;
                }
                else
                {
                    Console.WriteLine("Not Enough Money!");
                }
            }
        }
        public static void Special(string name)
        {
            foreach (var employee in employees)
            {
                if (employee.Name == name)
                {
                    employee.Special = true;
                }
            }
        }
        public static void Loan(string name)
        {
            foreach (var employee in employees)
            {
                if (employee.Name == name && employee.Loaned == false && employee.Special == true)
                {
                    employee.Loaned = true;
                    Console.WriteLine("Accepted");
                    switch (employee.Degree)
                    {
                        case 1:
                            employee.Balance += 3*100;
                            break;
                        case 2:
                            employee.Balance += 3*300;
                            break;
                        case 3:
                            employee.Balance += 3*700;
                            break;
                        case 4:
                            employee.Balance += 3*900;
                            break;

                    }
                    
                }
                else
                {
                    Console.WriteLine("Rejected");
                }
            }
        }
        public static void Promote() {
            foreach (var employee in employees)
            {
                if (employee.Special == true)
                {
                    //should I turn retired people's hired = false?
                    employee.Degree += 1;
                    if (employee.Degree == 5)
                    {
                        foreach (var e in employees)
                        {
                            if (e.Special == true && e.Loaned == true)
                            {
                                e.Loaned = false;
                            }
                        }
                        //retired people are exempt from loans
                        employee.Loaned = true;
                    }
                }
            }
        }
        public static void Regress()
        {
            foreach (var employee in employees)
            {
                if (employee.Special == false)
                {
                    employee.Degree -= 1;
                    //fired workers cannot get loans
                    if (employee.Degree == 0)
                    {
                        employee.Loaned = true;
                    }
                }
            }
        }
        public static void Report(string name)
        {
            foreach (var employee in employees)
            {
                if (employee.Name == name)
                {
                    //aske about the credit part? is it the same as special?
                    if (employee.Special == true)
                    {
                        Console.WriteLine("Name: Special {0} Degree: {1}" +
                        "Credit: {2}", employee.Name, employee.Degree, employee.Balance);
                    }
                    else
                    {
                        Console.WriteLine("Name: {0} Degree: {1}" +
                        "Credit: {2}", employee.Name, employee.Degree, employee.Balance);
                    }
                }
            }
        }
    }
    class Employee
    {
        public string Name;
        public int Degree;
        public double Balance;
        public bool Special = false;
        public bool Loaned = false;
        public bool Hired = false;
        public Employee(string name, int degree)
        {
            this.Name = name;
            this.Degree = degree;
            this.Balance = 0;
            this.Loaned = false;
            this.Special = false;
            this.Hired = true;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;

            while (!stop)
            {
                Console.WriteLine("Category: 1, Cart: 2, Exit: 3");
                int num1 = int.Parse(Console.ReadLine());

                if (num1 == 1)
                {
                    Console.WriteLine("Add Category: 1, Filter by Price: 2, Show Supply: 3");
                    int  n = int.Parse(Console.ReadLine());
                    continue;
                }

                if (num1 == 2)
                {

                    Console.WriteLine("Please Enter your name, last name, age, and phone number in one line: ");
                    string[] personalInfo = Console.ReadLine().Split(' ');
                    People me = new People(personalInfo[0], personalInfo[1], double.Parse(personalInfo[2]), personalInfo[3]);

                    //a list to save all the products in the shopping cart
                    List<Product> myCart = new List<Product>();

                    //creates an object of class Cart
                    Cart c = new Cart(me, myCart);

                    Console.WriteLine("Calculate total price: 1, Add product: 2");
                    int num2 = int.Parse(Console.ReadLine());

                    if (num2 == 1)
                    {
                        //else calc price
                        c.CalculatePrice();
                        continue;
                    }

                    if (num2 == 2)
                    {
                        //adding to the shopping cart
                        Console.Write("Please Enter how many products you want to buy: ");
                        int n = int.Parse(Console.ReadLine());

                        for (int i = 0; i < n; i++)
                        {
                            Console.Write("Product Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Product ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Product Price: ");
                            double price = double.Parse(Console.ReadLine());
                            Console.Write("Product Rating: ");
                            double rating = double.Parse(Console.ReadLine());
                            Product newPro = new Product(name, id, price, rating);
                            //adding to the list
                            myCart.Add(newPro);
                        }

                        //adding the product list to the object of class Cart
                        c.AddProductToCart(myCart);
                        continue;
                    }
                }

                if (num1 == 3)
                {
                    stop = true;
                    break;
                }
            }
        }
        //a method to get info from username
        public static void GetInfo()
        {
            Console.Write("Enter the product's name: ");
            string nameOf = Console.ReadLine();
            Console.Write("Enter the product's ID: ");
            int idOf = int.Parse(Console.ReadLine());
            Console.Write("Enter the product's rating: ");
            double ratingOf = double.Parse(Console.ReadLine());
            Console.Write("Enter the product's Price: ");
            double priceOf = double.Parse(Console.ReadLine());
        }
    }

    struct People
    {
        public string name;
        public string lastName;
        public double age;
        public string phoneNum
        {
            get { return this.phoneNum; }
            set
            {
                if (phoneNum.Length == 11 && phoneNum.Substring(0, 2) == "09")
                {
                    this.phoneNum = value;
                }
                else
                {
                    throw new Exception("Invalid Phone Number!");
                }
            }
        }
        public People(string name, string lastName, double age, string phoneNum)
        {
            this.name = name;
            this.lastName = lastName;
            this.age = age;
            this.phoneNum = phoneNum;
        }
    }
    class Product
    {
        List<Product> p = new List<Product>();
        public string Name { get; set; }
        //is this property necessary?
        public int Stock { get; set; }
        public int ID {
            get { return this.ID; }
            set
            {
                foreach (var item in p)
                {
                    if (item.ID != this.ID)
                    {
                        this.ID = value;
                    }
                }
            }
        }
        public double Price { get; set; }
        public double Rating { get; set; }
        //is protected right? or should I make it private?
        protected string Manufacturer { get; set; }
        public Product(string name,int id, double price, double rating)
        {
            this.Name = name;
            this.ID = id;
            this.Price = price;
            this.Rating = rating;
            if (1<this.ID && this.ID<5)
            {
                this.Manufacturer = "a";
            }
            if (5 <= this.ID && this.ID < 10)
            {
                this.Manufacturer = "b";
            }
            if (10 <= this.ID)
            {
                this.Manufacturer = "c";
            }
        }
    }
    class Category
    {
        enum categories
        {
            phone=1,
            car=2,
            watch=3,
            Tshirt=4,
            laptop=5,
            tablet=6,
            charger=7,
            glass= 8,
            robot=9
        }
        categories _id;
        categories _name;
        public Category(int id, string name)
        {
            this._id = id;
            this._name = name;
        }
        List<Product> products = new List<Product>();
        public void AddProductCategory(List<Product> t)
        {
            foreach (var item in t)
            {
                products.Add(item);
            }
        }
        public List<Product> FilterByPrice(double least, double most)
        {
            List<Product> priceRange = new List<Product>();
            foreach (var prodcut in products)
            {
                if (prodcut.Price <= least && prodcut.Price<=most)
                {
                    priceRange.Add(prodcut);
                }
            }
            return priceRange;
        }
        
        //figure it out later
        public void ShowSupply()
        {
            double min = products[0].Price;
            List<Product> sortedPrice = new List<Product>();
            //finds the min price
            foreach (var product in products)
            {
                if (product.Price<min)
                {
                    min = product.Price;
                }
            }

        }
    }

    class Cart
    {
        People person;
        List<Product> cart = new List<Product>();
        public Cart(People person, List<Product> product)
        {
            this.person = person;
            this.cart = product;
        }

        //isn't it better to use params[] instead of a list for products?
        public void AddProductToCart(List<Product> p)
        {
            foreach (var item in p)
            {
                cart.Add(item);
            }
        }
        public void CalculatePrice()
        {
            double Sum = 0;
            Console.WriteLine("Name: {0}, Last Name: {1}, Phone Number: {2}", 
                person.name, person.lastName, person.phoneNum);
            foreach (var item in cart)
            {
                Console.WriteLine("Product: {0}, Price{1}", item.Name, item.Price);
                Sum += item.Price;
            }
            Console.WriteLine("Total Price: {0}", Sum);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;

            while (!stop)
            {
                //then it takes the operation 
                Console.WriteLine("Add: 1, Delete: 2, Search: 3, List: 4, Sort by ID: 5, Sort by Name: 6, Exit: 7");
                int number = int.Parse(Console.ReadLine());

                //creating an object of the class Book to access the methods easier
                Book method = new Book();

                if (number == 1)
                {
                    bookInfo b = method.GetData();
                    //finally adding the book to the list
                    method.Add(b);
                    continue;
                }
                if (number == 2)
                {
                    Console.WriteLine("Enter the book's ID: ");
                    int id = int.Parse(Console.ReadLine());
                    method.Delete(id);
                    continue;
                }
                if (number == 3)
                {
                    Console.WriteLine("Enter the book's ID: ");
                    int id = int.Parse(Console.ReadLine());
                    method.Search(id);
                    continue;
                }
                if (number == 4)
                {
                    method.List();
                    continue;
                }
                if (number == 5)
                {
                    method.SortByID();
                    continue;
                }
                if (number == 6)
                {
                    method.SortByName();
                    continue;
                }
                if (number == 7)
                {
                    stop = true;
                    break;
                }
            }
        }
    }
    struct bookInfo
    {
        public string name;
        public string writer;
        public double price;
        public int id;
        public string publisher;
        public char flag;
        public bookInfo(string name, string writer, double price, 
            int id, string publisher, char flag)
        {
            this.name = name;
            this.writer = writer;
            this.price = price;
            this.id = id;
            this.publisher = publisher;
            this.flag = flag;
        }
    }
    class Book
    {
        List<bookInfo> books = new List<bookInfo>();
        public Book() { }
        //Adding books
        //public void Add(string name, string writer, double price,
        //int id, string publisher) {
        //    bookInfo newBook = new bookInfo(name,writer,price,id,publisher,' ');
        //    books.Add(newBook);
        //}
        public void Add(bookInfo b)
        {
            books.Add(b);
        }
        //deleting books
        public void Delete(int id)
        {
            if (0 < books.Count)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].id == id)
                    {
                        books[i] = new bookInfo(books[i].name, books[i].writer,books[i].price,
                            books[i].id, books[i].publisher, '*');
                    }
                }
            }
        }
        //searching book
        public void Search(int id)
        {
            if (0 < books.Count)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].id == id && books[i].flag!='*')
                    {
                        Console.WriteLine("Name: {0}, Writer: {1}, Price: {2}, Publisher: {4}",
                            books[i].name, books[i].writer, books[i].price, books[i].publisher);
                        break;
                    }
                    if (books[i].flag=='*')
                    {
                        throw new Exception("The book has been deleted!");
                    }
                    throw new Exception("Book not found!");
                }
            }
        }
        //prints the list of books and saves them in a file
        public void List()
        {
            if (0 < books.Count)
            {
                StreamWriter writer = new StreamWriter("books.txt");
                foreach (var book in books)
                {
                    if (book.flag != '*')
                    {
                        Console.WriteLine("ID: {5}, Name: {0}, Writer: {1}, Price: {2}, Publisher: {4}",
                            book.name, book.writer, book.price, book.publisher, book.id);
                        //writes the info to the file
                        writer.Write("ID: {5}, Name: {0}, Writer: {1}, Price: {2}, Publisher: {4}",
                            book.name, book.writer, book.price, book.publisher, book.id);
                    }
                }
                writer.Close();
            }
            else
            {

                throw new Exception("No books in the inventory!");
            }
        }
        //sort method
        public void SortByName()
        {
            books.Sort();
            Display(books,1);
            
        }
        public void SortByID()
        {
            books.Sort();
            Display(books, 2);
        }
        //display method
        public void Display(List<bookInfo> books,int i)
        {
            foreach (var book in books)
            {
                if (i==1)
                {
                    Console.WriteLine("Name: {0}", book.name);    
                }
                if (i==2)
                {
                    Console.WriteLine("ID: {0}", book.id);
                }
            }
        }

        public bookInfo GetData()
        {
            //first it takes the book info
            Console.Write("Enter the book's name: ");
            string bookName = Console.ReadLine();
            Console.Write("Enter the book's writer: ");
            string Writer = Console.ReadLine();
            Console.Write("Enter the book's price: ");
            double Price = double.Parse(Console.ReadLine());
            Console.Write("Enter the book's ID: ");
            int bookID = int.Parse(Console.ReadLine());
            Console.Write("Enter the book's publication: ");
            string Publisher = Console.ReadLine();

            //then it creates a bookInfo struct object
            bookInfo myBook = new bookInfo(bookName, Writer, Price, bookID, Publisher, ' ');
            return myBook;
        }
    }
}

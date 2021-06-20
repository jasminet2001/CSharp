using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShoppingApp
{
    class Library
    {
        public List<Books> books;

        string path = @"D:\AP\Exercise\Six\ShoppingApp\ShoppingApp\LibraryInfo.txt";
        public Library() {
            books = new List<Books>();
        }

        //a method to add and save media
        public void AddMedia()
        {
            //getting information from the admin
            Console.Write("Enter product type (Video,Book,Magazine): ");
            string type = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("ID: ");
            string id = Console.ReadLine();

            Console.Write("Price(No VAT): ");
            double price = double.Parse(Console.ReadLine());


            switch (type)
            {
                case "Video":

                    Console.Write("Duration: ");
                    double d = double.Parse(Console.ReadLine());
                    Console.Write("Number of CDs: ");
                    int n = int.Parse(Console.ReadLine());

                    Videos v = new Videos(id,name,price,d,n);
                    SaveVidMedia(v, path);

                    break;

                case "Book":

                    Console.Write("Publisher: ");
                    string pub = Console.ReadLine();
                    Console.Write("Author's name: ");
                    string a = Console.ReadLine();

                    Books b = new Books(id, name, price, a, pub);
                    SaveBookMedia(b, path);

                    break;

                case "Magazine":

                    Console.Write("Publisher: ");
                    string pubM = Console.ReadLine();
                    Console.Write("Number of Pages: ");
                    int num = int.Parse(Console.ReadLine());

                    Magazines m = new Magazines(id, name, price, pubM, num);
                    SaveMagazineMedia(m, path);

                    break;
            }
        }

        //a method to save video products
        public void SaveVidMedia(Videos v, string p)
        {
            if (File.Exists(p))
            {
                using (StreamWriter sw = File.AppendText(p))
                {
                    sw.WriteLine("ID: {0}", v.id);
                    sw.WriteLine("Name: {0}", v.productName);
                    sw.WriteLine("Price(No VAT): {0}", v.price);
                    sw.WriteLine("Number of CDs: {0}", v.cdNumber);
                    sw.WriteLine("Duration: {0}", v.Duration);
                }
            }
            if (!File.Exists(p))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.AppendText(p))
                {
                    sw.WriteLine("ID: {0}", v.id);
                    sw.WriteLine("Name: {0}", v.productName);
                    sw.WriteLine("Price(No VAT): {0}", v.price);
                    sw.WriteLine("Number of CDs: {0}", v.cdNumber);
                    sw.WriteLine("Duration: {0}", v.Duration);
                }
            }
        }

        //a method to save book products
        public void SaveBookMedia(Books b, string p)
        {
            if (File.Exists(p))
            {
                using (StreamWriter sw = File.AppendText(p))
                {
                    sw.WriteLine("ID: {0}", b.id);
                    sw.WriteLine("Name: {0}", b.productName);
                    sw.WriteLine("Price(No VAT): {0}", b.price);
                    sw.WriteLine("Publisher: {0}", b.publisher);
                    sw.WriteLine("Author: {0}", b.author);
                }
            }
            if (!File.Exists(p))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.AppendText(p))
                {
                    sw.WriteLine("ID: {0}", b.id);
                    sw.WriteLine("Name: {0}", b.productName);
                    sw.WriteLine("Price(No VAT): {0}", b.price);
                    sw.WriteLine("Publisher: {0}", b.publisher);
                    sw.WriteLine("Author: {0}", b.author);
                }
            }
        }

        //a method to save magazine products
        public void SaveMagazineMedia(Magazines m, string p)
        {
            if (File.Exists(p))
            {
                using (StreamWriter sw = File.AppendText(p))
                {
                    sw.WriteLine("ID: {0}", m.id);
                    sw.WriteLine("Name: {0}", m.productName);
                    sw.WriteLine("Price(No VAT): {0}", m.price);
                    sw.WriteLine("Number of Pages: {0}", m.Pages);
                    sw.WriteLine("Publisher: {0}", m.Publisher);
                }
            }
            if (!File.Exists(p))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.AppendText(p))
                {
                    sw.WriteLine("ID: {0}", m.id);
                    sw.WriteLine("Name: {0}", m.productName);
                    sw.WriteLine("Price(No VAT): {0}", m.price);
                    sw.WriteLine("Number of Pages: {0}", m.Pages);
                    sw.WriteLine("Publisher: {0}", m.Publisher);
                }
            }
        }

        //a method to delete media
        public void DelMedia()
        {
            Console.Write("Enter an id to remove: ");
            string id = "ID: " + Console.ReadLine();

            //a temp.txt file to temporarily hold the modified version
            string temp = @"D:\AP\Exercise\Six\ShoppingApp\ShoppingApp\temp.txt";
            int lineNum = 0;
            string[] lines = File.ReadAllLines(path);

            //finds the number of the line that has the given id
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(id))
                {
                    lineNum = i;
                    break;
                }
            }

            using (StreamWriter newSr = new StreamWriter(temp, true))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lineNum <= i && i <= lineNum + 4)
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
            if (File.Exists(path) && File.Exists(temp))
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
                File.Copy(temp, path, true);
            }

            //deletes the temp file after using it
            File.Delete(temp);
        }

        //a method to search for a media
        public void SearchMedia()
        {
            Console.Write("Enter the id to search: ");
            string id = "ID: " + Console.ReadLine();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(id))
                    {
                        Console.WriteLine(lines[i]);
                        Console.WriteLine(lines[i+1]);
                        Console.WriteLine(lines[i+2]);
                        Console.WriteLine(lines[i+3]);
                        Console.WriteLine(lines[i+4]);
                        break;
                    }
                }
            }
            if (!File.Exists(path))
            {
                throw new Exception("File Does not Exist!");
            }
        }

        //search media by name that return the info as an array
        public string[] SearchMediaByName()
        {
            Console.Write("Enter the name: ");
            string name = "Name: " + Console.ReadLine();

            //checks if the file is empty or not
            if (new FileInfo(path).Length != 0 && name != "Name: ")
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(name))
                    {
                        string[] mediaInfo = {lines[i-1], lines[i], lines[i+1], lines[i+2], lines[i+3]};
                        return mediaInfo;
                    }
                }
                //if the product isn't in the file
                Console.WriteLine("Sorry! The product you are looking for does not exist!");
            }
            if (name == "Name: ")
            {
                Console.WriteLine("Null input");
                return null;
            }
            else
            {
                Console.WriteLine("Sorry, The product file is empty!");
            }
            return null;
        }

    }
}

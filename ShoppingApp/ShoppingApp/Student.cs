using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ShoppingApp
{
    class Student
    {
        public string Name { get; set; }
        private string _id;
        public string ID
        {
            get { return _id; }
            set
            {
                Regex rg = new Regex(@"\b[9]\w+");
                _id = value;
                Match match = rg.Match(_id);

                if (match.Success && _id.Length == 8)
                {
                    _id = value;
                }

                else
                    throw new Exception("Student ID is incorrect");
            }
        }

        public Student(string name, string id)
        {
            this.Name = name;
            this.ID = id;
        }

        //change this method later
        public void SaveData()
        {

            string path = @"D:\AP\Exercise\Six\ShoppingApp\ShoppingApp\StudentsInfo.txt";

            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("Name: {0}", Name);
                    sw.WriteLine("ID: {0}", ID);
                }
            }
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Name: {0}", Name);
                    sw.WriteLine("ID: {0}", ID);
                }
            }
        }

    }
}

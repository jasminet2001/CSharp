using System.IO;

namespace ShoppingApp
{
    class Teacher
    {
        public string Name { get; set; }
        public string Institute { get; set; }
        public Teacher(string name, string inst)
        {
            Name = name;
            Institute = inst;
        }

        public void SaveData()
        {

            string path = @"D:\AP\Exercise\Six\ShoppingApp\ShoppingApp\TeachersInfo.txt";

            if (File.Exists(path))
            {
                StreamWriter sw = File.AppendText(path);
                sw.WriteLine("Name: {0}", Name);
                sw.WriteLine("Institute: {0}", Institute);
                sw.Close();
            }
            if (!File.Exists(path))
            {
                // Create a file to write to.
                StreamWriter sw = File.CreateText(path);
                sw.WriteLine("Name: {0}", Name);
                sw.WriteLine("Institute: {0}", Institute);
                sw.Close();
            }
        }

    }
}

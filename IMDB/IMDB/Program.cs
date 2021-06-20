using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"D:\AP\Exercise\Seven\IMDB\IMDB\IMDB-Movie-Data.csv")
                .Skip(1)
                .Select(line => new IMDBData(line));
            Console.WriteLine($"The film with highest metascore : {data.GetHighestMetascore().Title}");
            Console.WriteLine("----------------------------");

            // If necessary, you can use more than one extension method to calculate these answers.
            Console.WriteLine("Question 1: ");
            for (int i = 0; i < data.Runtime().Count; i++)
            {
                Console.WriteLine($"Genre: {data.Runtime()[i]}");
            }
            Console.WriteLine("----------------------------");

            Console.WriteLine("Question 2: ");
            for (int i = 0; i < data.Director().Count; i++)
            {
                Console.WriteLine($"Van Diesel Films' Directors: {data.Director()[i]}");
            }
            Console.WriteLine("----------------------------");

            Console.WriteLine("Question 3: ");
            Console.WriteLine($"The Highest Votes for a Film in 2016: {data.HighestMetascore2016().Title}");
            Console.WriteLine($"Genre: {data.HighestMetascore2016().Genre}");
            Console.WriteLine($"Director: {data.HighestMetascore2016().Director}");
            Console.WriteLine($"Year: {data.HighestMetascore2016().Year}");
            Console.WriteLine($"Actors: {data.HighestMetascore2016().Actor1}, " +
                $"{data.HighestMetascore2016().Actor2}, {data.HighestMetascore2016().Actor3}, " +
                $"{data.HighestMetascore2016().Actor4}");
            Console.WriteLine($"Runtime: {data.HighestMetascore2016().Runtime}");
            Console.WriteLine($"Rating: {data.HighestMetascore2016().Rating}");
            Console.WriteLine($"Votes: {data.HighestMetascore2016().Votes}");
            Console.WriteLine($"Rank: {data.HighestMetascore2016().Rank}");
            Console.WriteLine($"Metascore: {data.HighestMetascore2016().Metascore}");
            Console.WriteLine($"Revenue: {data.HighestMetascore2016().Revenue}");
            Console.WriteLine("----------------------------");

            Console.WriteLine("Question 4: ");
            foreach (var item in data.BryanSinger())
            {
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Revenue: {item.Revenue}");
            }
            Console.WriteLine("----------------------------");

            double sum = 0;
            foreach (var item in data.TotalRevenue())
            {
                sum += double.Parse(item.Revenue);
            }
            Console.WriteLine($"Question 5: {sum}");
            Console.WriteLine("----------------------------");

            Console.WriteLine("Question 6: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{data.LongAction()[i].Title}");
            }
            Console.WriteLine("----------------------------");

            Console.WriteLine($"Question 7: ");
            foreach (var item in data.NumFilms())
            {
                Console.WriteLine($"{item.Title}");
            }
            Console.WriteLine("----------------------------");

            Console.WriteLine($"Question 8: ");
            Console.WriteLine("Jennifer Lawrence:");
            foreach (var item in data.JLRatings())
            {
                Console.WriteLine(item.Title);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Anne Hathaway:");
            foreach (var item in data.AnneMovieDates())
            {
                Console.WriteLine(item.Title);
            }
            Console.WriteLine("----------------------------");

            Console.WriteLine($"Question 9: ");
            Console.WriteLine($"Count of Dramas Above 8.0 Score: {data.Drama()}");
            Console.WriteLine($"Count of Comedies Above 8.0 Score: {data.Comedy()}");
            if (data.Drama() < data.Comedy())
            {
                Console.WriteLine("Comedy movies are more than Drama movies");
            }
            else
            {
                Console.WriteLine("Drama movies are more than Comedy movies");
            }
            Console.WriteLine("----------------------------");

            Console.WriteLine($"Question 10: {data.ExtensionMethodPlaceHolder()}");
            Console.WriteLine("----------------------------");

            
            Console.ReadKey();
        }
    }


    //class that holds the datas of the films
    public class IMDBData
    {
        public IMDBData(string line)
        {
            var toks = line.Split(',');
            Rank = int.Parse(toks[0]);
            Title = toks[1].Trim();
            Genre = toks[2].Trim();
            Director = toks[3].Trim();
            Actor1 = toks[4].Trim();
            Actor2 = toks[5].Trim();
            Actor3 = toks[6].Trim();
            Actor4 = toks[7].Trim();
            Year = int.Parse(toks[8]);
            Runtime = int.Parse(toks[9]);
            Rating = (toks[10]);
            Votes = int.Parse(toks[11]);
            Revenue = toks[12].ParseStringOrNull();
            Metascore = toks[13].ParseIntOrNull();
        }
        public int Rank;
        public string Title;
        public string Genre;
        public string Director;
        public string Actor1;
        public string Actor2;
        public string Actor3;
        public string Actor4;
        public int Year;
        public int Runtime;
        public string Rating;
        public int Votes;
        public string Revenue;
        public Nullable<int> Metascore;
    }
}

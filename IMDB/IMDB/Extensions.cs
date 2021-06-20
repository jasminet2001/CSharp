using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    public static class Extensions
    {
        public static Nullable<int> ParseIntOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? int.Parse(str) as Nullable<int> : null;
        public static string ParseStringOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? str : null;

        //For example
        public static IMDBData GetHighestMetascore(this IEnumerable<IMDBData> data)
            => data.OrderByDescending(x => x.Metascore).First();

        /// <summary>
        /// you must modify the name of this method and its 
        /// implementation to fit your need and create more methods like this
        public static IMDBData ExtensionMethodPlaceHolder(this IEnumerable<IMDBData> data)
            => data.First();

        //less than 100min films
        public static List<string> Runtime(this IEnumerable<IMDBData> data) 
            => data.Where(x => x.Runtime < 100).GroupBy(x => x.Genre).Select(x => x.Key).ToList();

        //vin diesel films' directors
        public static List<string> Director(this IEnumerable<IMDBData> data)
            => data.Where(x => x.Actor1 == "\"Vin Diesel" || x.Actor2 == "Vin Diesel" || 
                x.Actor3 == "Vin Diesel" || x.Actor4 == "Vin Diesel")
                .Select(x => x.Director).ToList();

        //best score 2016
        public static IMDBData HighestMetascore2016(this IEnumerable<IMDBData> data)
            => data.Where(x => x.Year == 2016).
               OrderByDescending(x => x.Votes).First();

        //Bryan singer films
        public static IEnumerable<IMDBData> BryanSinger(this IEnumerable<IMDBData> data)
            => data.Where(x => x.Director == "Bryan Singer")
            .OrderByDescending(x => x.Revenue);

        //total revenue in 2011
        public static IEnumerable<IMDBData> TotalRevenue(this IEnumerable<IMDBData> data)
            => data.Where(x => x.Year == 2011);

        //question 6
        //ask about the diff in results?
        public static List<IMDBData> LongAction(this IEnumerable<IMDBData> data)
            => data.Where(x => x.Genre == "Action" && 120 < x.Runtime).OrderByDescending(x => x.Revenue)
                .ToList();

        //question 7
        public static IEnumerable<IMDBData> NumFilms(this IEnumerable<IMDBData> data)
            => data.Where(x => x.Title.Any(char.IsDigit));

        //question 8
        //Jennifer's movie ratings
        public static IEnumerable<IMDBData> JLRatings(this IEnumerable<IMDBData> data)
            => data.Where(x => x.Actor1 == "\"Jennifer Lawrence" || x.Actor2 == "Jennifer Lawrence" ||
                x.Actor3 == "Jennifer Lawrence" || x.Actor4 == "Jennifer Lawrence")
                .OrderByDescending(x => x.Rating);

        //Anne's movie based on date
        public static IEnumerable<IMDBData> AnneMovieDates(this IEnumerable<IMDBData> data)
            => data.Where(x => x.Actor1 == "\"Anne Hathaway" || x.Actor2 == "Anne Hathaway" ||
                x.Actor3 == "Anne Hathaway" || x.Actor4 == "Anne Hathaway")
                .OrderBy(x => x.Year);

        //question 9
        public static int Drama(this IEnumerable<IMDBData> data)
            => data.Where(x => x.Genre == "Drama" && 8 < double.Parse(x.Rating)).Count();
        public static int Comedy(this IEnumerable<IMDBData> data)
            => data.Where(x => x.Genre == "Comedy" && 8 < double.Parse(x.Rating)).Count();

        //question 10
        //public static List<string> WorstActor(this IEnumerable<IMDBData> data)
        //    => data.Where(x => double.Parse(x.Rating) < 7)
        //        .Select(x => new {x.Actor1, x.Actor2, x.Actor3, x.Actor4}).ToList();
    }
}

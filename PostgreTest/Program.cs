using PostgreTest.Models;
using System;

namespace PostgreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var db = new tutorialContext())
            {

                var date = DateTime.Now.AddDays(-1);
                Random rnd = new Random();
                for (int i = 0; i < 20000; i++)
                {
                    var xdate = date.AddMinutes(1);
                    var model = new GraphData() {
                        Time = xdate,
                        Average = rnd.Next(1, 1000),
                        Close = rnd.Next(1, 1000),
                        High = rnd.Next(1, 1000),
                        Low = rnd.Next(1, 1000),
                        Open = rnd.Next(1, 1000),
                        Total = rnd.Next(1, 1000),
                        Volume = rnd.Next(1, 1000),
                        Symbol = "BTCTRY",
                        Type = 1
                    };

                    db.GraphDatas.Add(model);
                    db.SaveChanges();
                    date = xdate;
                }
            }

            Console.WriteLine("bitti");
            Console.ReadLine();
        }
    }
}

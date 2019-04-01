using PostgreTest.Api.Models;
using PostgreTest.Models;
using System;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PostgreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello PostgreSql!");

 
            using (var db = new tutorialContext())
            {
                Random rnd = new Random();

                for (int z = 20; z > 0; z--)
                {
                    Console.WriteLine(z);
                    for (int i = 0; i < 1000; i++)
                    {
                        Console.WriteLine(i);

                        var model = new Models.TradeData()
                        {
                            CreatedDate = DateTime.Now.AddDays(-z).AddMinutes(-rnd.Next(1,59)),
                            Close = rnd.Next(1, 1000),
                            High = rnd.Next(1, 1000),
                            Low = rnd.Next(1, 1000),
                            Open = rnd.Next(1, 1000),
                            Volume = rnd.Next(1, 1000),
                            Symbol = "BTCTRY"
                        };

                        db.GraphDatas.Add(model);
                        db.SaveChanges();

                    }
                }
            
              
            }

            Console.WriteLine("bitti");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB;

namespace MongoDB_Loader
{
    class Program
    {
        static void Main(string[] args)
        {
            int numItems = 100000;
            DateTime start, end;

            var mongo = new Mongo();
            mongo.Connect();

            var db = mongo.GetDatabase("test");

            var logs = db.GetCollection("logs");

            var query = logs.FindAll();

            start = DateTime.Now;
            for (int i = 0; i < numItems; i++)
            {
                var log = new Document();
                log["DateInserted"] = DateTime.Now;
                log["SeqNum"] = Guid.NewGuid();
                log["Reference"] = String.Format("Hey {0}", i.ToString());

                logs.Insert(log);
            }
            end = DateTime.Now;

            Console.WriteLine("Inserted " + numItems + " in " + end.Subtract(start).TotalMilliseconds + "ms");
            Console.ReadLine();
        }
    }
}

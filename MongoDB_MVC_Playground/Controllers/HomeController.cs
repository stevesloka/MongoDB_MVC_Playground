using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB_MVC_Playground.Models;
using MongoDB;

namespace MongoDB_MVC_Playground.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mongo = new Mongo();
            mongo.Connect();

            var db = mongo.GetDatabase("test");

            var query = db.GetCollection("logs").FindAll().Documents;

            List<Models.HomeModel> homelist = new List<Models.HomeModel>();

            foreach (var q in query)
            {
                homelist.Add(new HomeModel(q["_id"].ToString(), (Guid)q["SeqNum"], (DateTime)q["DateInserted"], (q["Reference"] ?? String.Empty).ToString()));
            }

            return View(homelist);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

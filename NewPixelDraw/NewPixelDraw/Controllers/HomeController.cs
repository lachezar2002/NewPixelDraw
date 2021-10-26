using NewPixelDraw.Data;
using NewPixelDraw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewPixelDraw.Controllers
{
    public class HomeController : Controller
    {
        Acc accaunt = new Acc();

        private readonly ApplicationDB database;
        public HomeController() {
            this.database = new ApplicationDB();
        }
        public ActionResult Index()
        {



            return View(database);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(accaunt);
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DrawyourPicture(string color)
        {

            Pixi pix = new Pixi();
            pix.Colors = color;
            pix.name = "pesho";
            pix.PixiPosition = 3;
            database.Pixi.Add(pix);
            database.SaveChanges();
            ViewBag.Message = "Your contact page.";

            return View(database);
        }
        public ActionResult CreateAcc(string user, string password)
        {
            Acc acc = new Acc();
            acc.Password = password;
            acc.Username = user;
            acc.Login = false;

            this.database.Acc.Add(acc);
            this.database.SaveChanges();
            ViewBag.Message = "Your contact page.";
            accaunt = acc;
            Session["user"] = acc.Username;
            return View(database);
        }
        public void pesho(){

            Pixi pix = new Pixi();
            pix.Colors = "rrr";
            pix.name = "gosho";
            pix.PixiPosition = 3;
            database.Pixi.Add(pix);
            database.SaveChanges();
        }
    }
}
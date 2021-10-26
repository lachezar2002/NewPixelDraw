using NewPixelDraw.Data;
using NewPixelDraw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Globalization;


namespace NewPixelDraw.Controllers
{
    public class HomeController : Controller
    {
       
        Acc accaunt = new Acc();

        private readonly ApplicationDB database;
        public void HandleTimer() {
            Redirect("About");
        }
        public HomeController()
        {
   
            this.database = new ApplicationDB();
        }
        public ActionResult Index(string Id)
        {

            if (database.Wff.FirstOrDefault(c => c.Room == Id) != null) { 
            
            database.Wff.Remove(database.Wff.FirstOrDefault(c => c.Room == Id));
            database.Room.Remove(database.Room.FirstOrDefault(c => c.roomname == Id));
                database.SaveChanges();
        }
            return View(database);
        }
        [HttpGet]
      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(accaunt);
        }

        public ActionResult Contact()
        {

            return View(database);
        }

        public ActionResult testajax(string Id)
        {

            List<Pixi> pixis = new List<Pixi>();
            foreach (Pixi pixi in database.Pixi.ToList())
            {
                if (pixi.name == Id)
                {
                    pixis.Add(pixi);
                }
            }
            ViewBag.Message = "Your contact page.";

            return Json(pixis, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Word(string Id)
        {

            List<Wordforfamiliarity> Word = new List<Wordforfamiliarity>();
            foreach (Wordforfamiliarity pixi in database.Wff.ToList())
            {
                if (pixi.Room == Id)
                {
                    Word.Add(pixi);
                }
            }
            ViewBag.Message = "Your contact page.";

            return Json(Word, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Room(string Id)
        {
         
            List <Room> Allroom = new List<Room>();
            foreach (Room room in database.Room.ToList())
            {
                if (room.roomname == Id)
                {
                    Allroom.Add(room);
                    if(room.player1 != null && room.player2 != null && room.player3 != null && room.player4 != null)
                    {
                        
                        database.Room.Remove(room);
                        database.Wff.Remove(database.Wff.FirstOrDefault(c => c.Room == Id));
                        database.SaveChanges(); 
                    }
                    
                }
               
            }
            ViewBag.Message = "Your contact page.";
        

            return Json(Allroom, JsonRequestBehavior.AllowGet);
        }
         


        public ActionResult Chat(string Id)
        {

            List<chat> Chata = new List<chat>();
            foreach (chat Chats in database.Chat.ToList())
            {
                if (Chats.Room == Id)
                {
                    Chata.Add(Chats);
                    
                }
            }
            ViewBag.Message = "Your contact page.";

            return Json(Chata, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DrawyourPicture(string id, string color, string position, string chat)
        {

            
            if (ViewBag.CheckJoin == ViewBag.roombox)
            {

                Pixi pixi = new Pixi();
                pixi.name = id;

                pixi.PixiPosition = position;

                pixi.Colors = color;
                database.Pixi.Add(pixi);
                database.SaveChanges();
            }
            if (Session["Username"] != null)
            {
                if (chat != null)
                {
                    if (database.Wff.FirstOrDefault(c => c.Room == id).Word1 == chat)
                    {
                        database.Wff.FirstOrDefault(c => c.Room == id).P1 = Session["Username"].ToString();
                        database.SaveChanges();
                    }
                    if (database.Wff.FirstOrDefault(c => c.Room == id).Word2 == chat)
                    {
                        database.Wff.FirstOrDefault(c => c.Room == id).P2 = Session["Username"].ToString();
                        database.SaveChanges();
                    }
                    if (database.Wff.FirstOrDefault(c => c.Room == id).Word3 == chat)
                    {
                        database.Wff.FirstOrDefault(c => c.Room == id).P3 = Session["Username"].ToString();
                        database.SaveChanges();
                    }
                    if (database.Wff.FirstOrDefault(c => c.Room == id).Word4 == chat)
                    {
                        database.Wff.FirstOrDefault(c => c.Room == id).P4 = Session["Username"].ToString();
                        database.SaveChanges();
                    }
                    chat Chat = new chat();
                    Chat.Chat = Session["Username"].ToString()+" : " + chat;
                    Chat.Room = id;
                    Chat.player = Session["Username"].ToString();
                    database.Chat.Add(Chat);
                    database.SaveChanges();
                }
            }
           
            Wordforfamiliarity word = database.Wff.FirstOrDefault(c => c.Room == id);
            return View(word);
        }
        [HttpGet]
        public ActionResult DrawyourPicture(string id)
        {
            ViewBag.roombox = id;
            Wordforfamiliarity word = database.Wff.FirstOrDefault(c => c.Room == id);
            return View(word);
        }
        public ActionResult CreateandLogin(string password, string username, string email)
        {

            return View();
        }

        public ActionResult JoinRoom(string Room, string password, string CreateRoom, string CreatePassword)
        {

            if (Room == "Rand456789010")
            {
                foreach (Room r in database.Room.ToList())
                {
                    if (r.password == "")
                    {
                        if (r.player1 == null)
                        {
                            r.player1 = Session["Username"].ToString();

                            database.SaveChanges();
                            return Redirect("DrawyourPicture/" + r.roomname.ToString());
                        }
                        if (r.player2 == null)
                        {
                            r.player2 = Session["Username"].ToString();

                            database.SaveChanges();
                            return Redirect("DrawyourPicture/" + r.roomname.ToString());
                        }
                        if (r.player3 == null)
                        {
                            r.player3 = Session["Username"].ToString();
                            database.SaveChanges();
                            return Redirect("DrawyourPicture/" + r.roomname.ToString());
                        }
                        if (r.player4 == null)
                        {
                            r.player4 = Session["Username"].ToString();
                            database.SaveChanges();
                            return Redirect("DrawyourPicture/" + r.roomname.ToString());
                        }

                    }

                }

            }


            if (CreateRoom != null)
                {
                    if (database.Room.FirstOrDefault(c => c.roomname == CreateRoom) != null)
                    {
                        ViewBag.ValidRoom = "  This Room already created";
                    }
                    if (database.Room.FirstOrDefault(c => c.roomname == CreateRoom) == null)
                    {

                        Room arfus = new Room();
                        arfus.password = CreatePassword;
                        arfus.roomname = CreateRoom;

                        arfus.player1 = Session["Username"].ToString();
                        arfus.player2 = null;
                        arfus.player3 = null;
                        arfus.player4 = null;

                    List<string> Word = new List<string>();
                    Word.Add("car");
                    Word.Add("dog");
                    Word.Add("youtube");
                    Word.Add("cat");
                   Word.Add("snake");
                   Word.Add("motor");
                   Word.Add("monitor");
                   Word.Add("facebook");
                   Word.Add("man");
                    Word.Add("keyboard");
                    Word.Add("football");
                    Word.Add("europe");
                    Word.Add("africa");
                   Word.Add("amerika");
                    Word.Add("australia");


                    Random rnd = new Random();
                    int Word1 = rnd.Next(0, 13);
                    int Word2 = rnd.Next(0, 13);
                    int Word3 = rnd.Next(0, 13);
                    int Word4 = rnd.Next(0, 13);
                    Wordforfamiliarity wordforfamiliarity = new Wordforfamiliarity();
                    wordforfamiliarity.Word1 = Word[Word1];
                    wordforfamiliarity.Word2 = Word[Word2];
                    wordforfamiliarity.Word3 = Word[Word3];
                    wordforfamiliarity.Word4 = Word[Word4];

                    wordforfamiliarity.Room = CreateRoom;
                    database.Wff.Add(wordforfamiliarity);
                    database.Room.Add(arfus);
                        database.SaveChanges();
                        if (CreateRoom != null)
                        {
                            return Redirect("DrawyourPicture/" + CreateRoom);

                        }
                    }
                }
                if (Room != null)
                {
                    if (database.Room.FirstOrDefault(c => c.roomname == Room) != null)
                    {
                        if (database.Room.FirstOrDefault(c => c.roomname == Room).password == password)
                        {
                            Room checkplayers = database.Room.FirstOrDefault(c => c.roomname == Room);
                            if (checkplayers.player2 == null)
                            {

                                checkplayers.player2 = Session["Username"].ToString();
                                database.SaveChanges();
                                ViewBag.CheckJoin = Room;
                                return Redirect("DrawyourPicture/" + Room);
                            }
                            if (checkplayers.player3 == null)
                            {

                                checkplayers.player3 = Session["Username"].ToString();
                                database.SaveChanges();
                                ViewBag.CheckJoin = Room;
                                return Redirect("DrawyourPicture/" + Room);
                            }
                            if (checkplayers.player4 == null)
                            {
                                checkplayers.player4 = Session["Username"].ToString();
                                database.SaveChanges();
                                ViewBag.CheckJoin = Room;
                                return Redirect("DrawyourPicture/" + Room);
                            }
                            else
                            {
                                ViewBag.validation = "Room is full";
                            }
                        }
                    }
                }
            
            return View();
        }



        [HttpGet]
        public ActionResult JoinRoom()
        {

            return View();
        }
        public ActionResult CreateAcc(string user, string password, string userlog, string passwordlog, string Email, string forgotten)
        {


            ViewBag.Emailisnotfound = null;
            ViewBag.Usernameisnotcurrect = null;
            ViewBag.Emailalready = null;
            if (database.Acc.FirstOrDefault(c => c.Username == user) != null)
            {
                ViewBag.Usernameisnotcurrect = "This name already used";
            }
            if (database.Acc.FirstOrDefault(c => c.Email == Email) != null)
            {
                ViewBag.Emailalready = "This Email already used";
            }


            if (user != null && password != null && database.Acc.FirstOrDefault(c => c.Username == user) == null && database.Acc.FirstOrDefault(c => c.Email == Email) == null)
            {

                Session["Username"] = user;
                Acc acc = new Acc();
                acc.Password = password;
                acc.Username = user;
                acc.Email = Email;

                this.database.Acc.Add(acc);
                this.database.SaveChanges();
                ViewBag.Message = "Your contact page.";

                ViewBag.Usernameisnotcurrect = "Your Acount is ready to use";
            }
         
            if (userlog != null && passwordlog != null)
            {

                foreach (Acc acc in database.Acc.ToList())
                {

                    if (acc.Username == userlog)
                    {
                        if (acc.Password == passwordlog)
                        {
                            Session["Username"] = userlog;
                            Session["Password"] = passwordlog;
                            return Redirect("About");
                        }
                    }
                }

            }
            if (forgotten != null)
            {
                if (database.Acc.FirstOrDefault(c => c.Email == forgotten) != null) {
                    var ForgotenAccount = database.Acc.FirstOrDefault(c => c.Email == forgotten);
                    using (var client = new SmtpClient("smtp.googlemail.com", 587))
                    {
                        client.EnableSsl = false;
                        client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        client.Credentials = new System.Net.NetworkCredential("NewPixelDraw@gmail.com", "newpixeldraw2002");
                        client.EnableSsl = true;
                        var msg = new MailMessage("NewPixelDraw@gmail.com", forgotten);

                        msg.Subject = "Password";
                        msg.Body = "Username: " + ForgotenAccount.Username + " Password: " + ForgotenAccount.Password + "; EditPassord " + "http://localhost:52975/Home/EditPassword/" + ForgotenAccount.Id;

                        client.Send(msg);
                    }
                }
                else
                {
                    ViewBag.Emailisnotfound = "Email not found";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateAcc()
        {

            return View();
        }

        public ActionResult EditPassword(int Id, string password, string Email)
        {

            ViewBag.validatemail = null;
            Acc acc = database.Acc.FirstOrDefault(c => c.Id == Id);
                if (acc.Email == Email)
                {
                    acc.Password = password;
                    database.SaveChanges();
                ViewBag.validatemail = "Your Acc is ready to use with new password";
                }
                else
                {
                    ViewBag.validatemail = "wrongemail";
                }

            
            return View();
        }


        [HttpGet]
        public ActionResult EditPassword()
        {


            return View();
        }

    }
}

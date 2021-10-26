using NewPixelDraw.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewPixelDraw.Data
{
    public class ApplicationDB : DbContext
    {
       public ApplicationDB() : base("Context") {
        }
      public IDbSet<Pixi> Pixi { get; set; }
      public IDbSet<Acc> Acc { get; set; }
      public IDbSet<Room> Room { get; set; }
        public IDbSet<chat> Chat { get; set; }
        public IDbSet<Wordforfamiliarity> Wff { get; set; }
    }
}
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
       public ApplicationDB() : base("Default") {
        }
      public IDbSet<Pixi> Pixi { get; set; }
      public IDbSet<Acc> Acc { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewPixelDraw.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string roomname { get; set;}
        public string password { get; set; }
        public string player1 { get; set; }
        public string player2 { get; set; }
        public string player3 { get; set; }
        public string player4  { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace NewPixelDraw.Models
{
    public class chat
    {

        [Key]
        public int Id { get; set; } 
        public string Chat { get; set; }
        public string player { get; set; }
        public string Room { get; set; }
    }
}
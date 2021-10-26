using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace NewPixelDraw.Models
{
    public class Wordforfamiliarity
    {
        [Key]
        public int Id { get; set; }
        public string Room { get; set; }
        public string Word1{ get; set; }
        public string P1 { get; set; }
        public string Word2 { get; set; }
        public string P2 { get; set; }
        public string Word3 { get; set; }
        public string P3 { get; set; }
        public string Word4 { get; set; }
        public string P4 { get; set; }
    }
}
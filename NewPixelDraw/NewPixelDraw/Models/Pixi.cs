using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewPixelDraw.Models
{
    public class Pixi
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }

        public int PixiPosition { get; set; }
        public string Colors { get; set; }
    }
}
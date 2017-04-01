using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWikiAPI.Models
{
    public class BandDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public System.DateTime formationDate { get; set; }
        public string genre { get; set; }
    }
}
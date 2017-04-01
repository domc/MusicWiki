using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicWikiAPI.Models
{
    public class BandDTO
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class BandDetailDTO
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string country { get; set; }

        [Required]
        public System.DateTime formationDate { get; set; }

        [Required]
        public string genre { get; set; }
    }
}
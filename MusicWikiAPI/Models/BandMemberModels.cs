using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicWikiAPI.Models
{
    public class BandMemberCreateDTO
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string role { get; set; }

        [Required]
        public int bandID { get; set; }
    }

    public class BandMemberEditDTO
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string role { get; set; }

        [Required]
        public int bandID { get; set; }
    }

    public class BandMemberDTO
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string band { get; set; }
    }

    public class BandMemberDetailDTO
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string role { get; set; }
        public string band { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Music_Library.Models
{
    [Table("tblSongs")]
    public class Songs
    {
        
        public string song_name { get; set; }
        public string song_artist { get; set; }
        public string song_category { get; set; }
        public string language { get; set; }
        public string lyrics { get; set; }
    }
}
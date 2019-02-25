using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Online_Music_Library.Models
{
    public class SongModel
    {
        public int song_id { get; set; }
        [DisplayName("Song Name")]
        public string song_name { get; set; }
        public string song_artist { get; set; }
        public string song_category { get; set; }
        public string language { get; set; }
        public string lyrics { get; set; }

    }
}
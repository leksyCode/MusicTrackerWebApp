using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MusicTrackerWebApp
{


    public class Lyric
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Lyrics { get; set; }
    }
}
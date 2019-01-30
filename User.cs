using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicTrackerWebApp
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
        public int BestScore { get; set; }
        public string Message { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MusicTrackerWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static string currentSong;
        static List<int> exSongs = new List<int>();
        static Random rnd = new Random(DateTime.Now.Millisecond);
        int randSong = rnd.Next(0, 10);
        public static User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                ShowUsers(0 /*mode*/);
                AnswerBox.Visible = false;
                AnswerButton.Visible = false;
                ReloadData.Visible = false;
                Disconnect.Visible = false;
            }
            else
            {
                Disconnect.Visible = true;
                ShowUsers(1 /*mode*/);
            }
            
        }

        protected void SetData(Object obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj.GetType().Equals("Lyric"))
                {
                    db.Lyrics.Add((Lyric)obj);
                }
                else
                {
                    db.Users.Add((User)obj);
                }            
            }
        }

        protected void UpdateData(Object obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Update(obj);
                db.SaveChanges();
            }
        }

        protected void DeleteData(string table)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (table == "Users")
                {
                    var users = db.Users.Where(a => a.Id > 2);
                    db.Users.RemoveRange(users);
                }
                else if (table == "Lyrics")
                {
                    var lyric = db.Lyrics.Where(a => a.Id > 11);
                    db.Lyrics.RemoveRange(lyric);
                }
                db.SaveChanges();
            }
        }

        protected void ShowUsers(int mode)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                if (mode == 0)
                {
                    Lyrics.Text = null;
                    foreach (var u in users)
                    {
                        Lyrics.Text += $"{u.Id}. {u.Login} - score: {u.Score}\t\t\t best score: {u.BestScore}\n";
                    }
                }
                else if (mode == 1)
                {
                    User1.Text = $"{currentUser.Login} - score: {currentUser.Score}";
                }
            }
        }

        

        protected void ShowLyric()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var lyricsList = db.Lyrics.ToList();

                do
                {
                    randSong = rnd.Next(0, 11);
                    if (exSongs.Count >= lyricsList.Count)
                    {                      
                        if (currentUser.Score > currentUser.BestScore)
                        {
                            currentUser.BestScore = currentUser.Score;
                        }
                        AnswerBox.Visible = false;
                        AnswerButton.Visible = false;
                        UpdateData(currentUser);
                        ShowUsers(0);
                        return;
                    }
                } while (exSongs.Contains(randSong));          

                Lyrics.Text = $"{lyricsList[randSong].Lyrics} \n";
                currentSong = lyricsList[randSong].Artist;
                exSongs.Add(randSong);
            }
        }

        protected void AnswerButton_Click(object sender, EventArgs e)
        {
            if (AnswerBox.Text == currentSong)
            {
                currentUser.Score++;
                UpdateData(currentUser);
            }
            ShowLyric();
            ShowUsers(1);
        }

        protected void ConnectButton_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();

                foreach (var u in users)
                {
                    if (LoginBox.Text == u.Login && PasswordBox.Text == u.Password)
                    {
                        currentUser = u;
                        
                        ReloadData.Visible = true;
                        LoginBox.Visible = false;
                        PasswordBox.Visible = false;
                        ConnectButton.Visible = false;
                    }
                }
            }
        }

        protected void Disconnect_Click(object sender, EventArgs e)
        {
            currentUser = null;
            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }

        protected void ReloadData_Click(object sender, EventArgs e)
        {
            AnswerBox.Visible = true;
            AnswerButton.Visible = true;
            currentUser.Score = 0;
            UpdateData(currentUser);
            exSongs.Clear();
            ShowLyric();
            ShowUsers(1);
        }
    }
}
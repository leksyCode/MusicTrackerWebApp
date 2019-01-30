using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace MusicTrackerWebApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Lyric> Lyrics { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
                  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:anton32.database.windows.net,1433;Initial Catalog=MusicTrackerDB;Persist Security Info=False;User ID=leksyCode;Password=Bender888;
                                      MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
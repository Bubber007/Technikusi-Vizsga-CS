using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilots_GUI
{
    public class AppContext : DbContext
    {
        public DbSet<Pilot> Pilots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=f1pilots;Uid=root;Pwd=;", ServerVersion.AutoDetect("Server=localhost;Database=f1pilots;Uid=root;Pwd=;"));
        }

    }
}

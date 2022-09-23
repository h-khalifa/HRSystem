using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class HREntities:DbContext
    {
        //public HREntities(DbContextOptions options) :base(options)
        //{

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Employe>()
                        

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Server=.\\SQLEXPRESS;Database=HR_Company;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(conn);
        }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
    }
}

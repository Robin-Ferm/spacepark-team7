using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SpacePort
{
    public class MyContext : DbContext
    {
        
        public virtual DbSet<Pay> Pay { get; set; }
        public virtual DbSet<Park> Park { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }

        public MyContext() : base()
        {
            
        }

        //Byt connection string så det funkar för dig
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=SpacePortDB;Trusted_Connection=True;");
        }
    }
}
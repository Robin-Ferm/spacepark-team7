using Microsoft.EntityFrameworkCore;

namespace SpacePort
{
    public class MyContext : DbContext
    {
        
        public DbSet<Pay> Pay { get; set; }
        public DbSet<Park> Park { get; set; }

        public MyContext() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(local);Database=SpacePortDB;Trusted_Connection=True;");
        }
    }
}
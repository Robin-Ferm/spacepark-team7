using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePort
{
    public class MyContext : DbContext
    {
        public DbSet<Pay> Pay { get; set; }
        public DbSet<Park> Park { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(local);Database=SpacePortDB;Trusted_Connection=True;");
        }
    }
}

public class Pay
{
    public int ID { get; set; }
    public int Invoice { get; set; }
    [ForeignKey("ParkID")]
    public int ParkID { get; set; }
    public Park Park { get; set; }
}

public class Park
{
    public int ID { get; set; }
    public string PersonName { get; set; }
    public string SpaceShip { get; set; }
    public DateTime ArrivalTime { get; set; }
}

using Microsoft.EntityFrameworkCore;
using System;

namespace SpacePort
{
    public static class DBMethods
    {
        public static void AddParking()
        {
            using (var db = new MyContext())
            {
                string name = "";
                string spaceship = "";

                var park = new Park{PersonName = name, SpaceShip = spaceship, ArrivalTime =  DateTime.Now};

                db.Park.Add(park);
                db.SaveChanges();

            }
        }
    }
}

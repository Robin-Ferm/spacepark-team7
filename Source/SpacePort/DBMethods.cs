using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace SpacePort
{
    public static class DBMethods
    {
        public static void AddParking(string name, string spaceShip )
        {
            using (var db = new MyContext())
            {
                var park = new Park{PersonName = name, SpaceShip = spaceShip, ArrivalTime =  DateTime.Now};

                db.Park.Add(park);
                db.SaveChanges();

            }
        }

        public static bool AlreadyParked(string name)
        {
            using (var db = new MyContext())
            {
                if (db.Park.Any(p => p.PersonName == name))
                {
                    
                    var query = db.Park
                        .Where(p => p.PersonName == name)
                        .OrderByDescending(p => p.ID)
                        .Select(p => p.Payed).First();

                    if (query)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public static void PayForParking(string name)
        {
            using (var db = new MyContext())
            {
                var query = db.Park
                    .Where(e => e.PersonName == name)
                    .OrderByDescending(e => e.ID)
                    .FirstOrDefault();

                DateTime departTime = DateTime.Now;
                TimeSpan timeParked = departTime - query.ArrivalTime;

                if (query != null)
                {
                    var pay = new Pay { DepartTime = departTime, ParkID = query.ID };
                    db.Pay.Add(pay);
                    query.Payed = true;
                    db.SaveChanges();
                    ShowReceipt(name, timeParked);
                }
                else
                {
                    Console.WriteLine("You have not parked before");
                    Program.Continue();
                }
            }
        }

        public static void ShowReceipt(string name, TimeSpan timeParked)
        {
            using (var db = new MyContext())
            {
                var query = db.Park
                    .Where( x => x.PersonName == name)
                    .OrderByDescending(x => x.ID)
                    .Join(
                    db.Pay,
                    park => park.ID,
                    pay => pay.ParkID,
                    (park, pay) => new
                    {
                        ID = pay.ID,
                        PersonName = park.PersonName,
                        SpaceShip = park.SpaceShip
                    }).FirstOrDefault();
                    
                double totalPrice = Math.Round(timeParked.TotalHours * 10000, 2);

                var receipt = new Receipt { PayID = query.ID, PersonName = query.PersonName, SpaceShip = query.SpaceShip, Price = totalPrice};
                db.Receipts.Add(receipt);
                db.SaveChanges();

                Console.WriteLine($"{query.PersonName} parked with {query.SpaceShip}");
                Console.WriteLine($"{query.PersonName} paid {totalPrice} credits for the parking");
                Program.Continue();
            }

            
        }

        public static bool EmptySpaces()
        {
            using (var db = new MyContext())
            {
                var query = db.Park
                    .Where(p => p.Payed == false)
                    .Count();

                if (query < 10)
                {
                    Console.WriteLine($"There are {10 - query} parking spaces left");
                    return true;
                }
                else
                {
                    Console.WriteLine("Sorry, all the parking spaces are occupied, please come back later");
                    Program.Continue();
                    return false;
                }
            }
        }
        public static void AlreadyPaid(string name)
        {
            using (var db = new MyContext())
            {
                var query = db.Park
                    .Where(p => p.PersonName == name)
                    .OrderByDescending(p => p.ID)
                    .Select(p => p.Payed).FirstOrDefault();
                    
                if (query)
                {
                    Console.WriteLine();
                    Console.WriteLine("You have already paid for your last parking");
                    Program.Continue();
                }
                else
                {
                    PayForParking(name);
                }
            }
        }
    }
}

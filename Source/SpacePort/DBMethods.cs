using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

                var query = (from p in db.Park
                             where p.PersonName == name
                             orderby p.ID descending
                             select p.ID).FirstOrDefault();

                if (query == 0)
                {
                    return false;
                }
                else
                {
                    var query2 = (from e in db.Pay
                                 join d in db.Park on e.ParkID equals d.ID
                                 where e.ParkID == query
                                 select e).FirstOrDefault();


                    if (query2 == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static void PayForParking(string name)
        {
            using (var db = new MyContext())
            {
                var query = (from e in db.Park
                             where e.PersonName == name
                             orderby e.ID descending
                             select e).FirstOrDefault();

                DateTime departTime = DateTime.Now;
                TimeSpan timeParked = departTime - query.ArrivalTime;

                if (query != null)
                {
                    var pay = new Pay { DepartTime = departTime, ParkID = query.ID };
                    db.Pay.Add(pay);
                    db.SaveChanges();
                    ShowReceipt(name, timeParked);
                }
                else
                {
                    Console.WriteLine("You have not parked before");
                }
            }
        }

        public static void ShowReceipt(string name, TimeSpan timeParked)
        {
            using (var db = new MyContext())
            {
                var query = (from p in db.Park
                             where p.PersonName == name
                             orderby p.ID descending
                             select p).FirstOrDefault();

                var query2 = (from e in db.Pay
                              join d in db.Park on e.ParkID equals d.ID
                              where e.ParkID == query.ID
                              select e).FirstOrDefault();


                
                double totalPrice = Math.Round(timeParked.TotalHours * 10000, 2);

                var receipt = new Receipt { PayID = query2.ID, PersonName = query.PersonName, SpaceShip = query.SpaceShip, Price = totalPrice};
                db.Receipts.Add(receipt);
                db.SaveChanges();

                Console.WriteLine($"{query.PersonName} parked with {query.SpaceShip}");
                Console.WriteLine($"{query.PersonName} payed {totalPrice} credits for the parking");
            }
        }
    }
}

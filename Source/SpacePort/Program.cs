using System;

namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu.ShowMenu("Welcome", new string[] { "Park", "Pay for parking" });

            var e = Api.ValidateName("Luke Skywalker");
            Console.WriteLine(e.Result);

            //var e = Api.GetStarShips();
            //foreach (var item in e.Result)
            //{
            //    Console.WriteLine(item.Name);
            //}

        }
    }
}

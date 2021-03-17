using System;

namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu.ShowMenu("Welcome", new string[] { "Park", "Pay for parking" });
            Api test = new Api();
            var e = test.ValidateName("Luke Skywalker");
            Console.WriteLine(e.Result);

        }
    }
}

using System;

namespace SpacePort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var alt = new string[] { "Park", "Pay for parking", "Exit" };
            object selected = alt;
            while (selected.ToString() != "Exit")
            {
                selected = Menu.ShowMenu("Welcome", new string[] { "Park", "Pay for parking", "Exit" });
                Menu.SelectedMenuChoice(selected);
            }

        }

        public static void Continue()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue!");
            Console.ReadLine();
        }
    }
}

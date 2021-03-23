using System;

namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {
            object selected = Menu.ShowMenu("Welcome", new string[] { "Park", "Pay for parking", "Exit" });

            Menu.SelectedMenuChoice(selected);


        }
    }
}

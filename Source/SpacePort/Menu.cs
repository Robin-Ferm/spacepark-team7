using SpacePort.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort
{
    class Menu
    {
        public static object ShowMenu(string info, object[] options)
        {
            if (options.Length <= 0 || options == null)
            {
                throw new ArgumentException("Options is empty.");
            }

            Console.CursorVisible = false;
            int selected = 0;

            HighlightMenuOption(info, options, selected);

            ConsoleKey key = Console.ReadKey().Key;

            while(key != ConsoleKey.Enter)
            {
                if (key == ConsoleKey.UpArrow && selected > 0)
                {
                    selected--;
                    HighlightMenuOption(info, options, selected);
                }
                else if (key == ConsoleKey.DownArrow && selected < options.Length -1)
                {
                    selected++;
                    HighlightMenuOption(info, options, selected);
                }

                key = Console.ReadKey().Key;
            }

            return options[selected];

        }
        public static void HighlightMenuOption(string info, object[] options, int index)
        {
            //Clear the console so it doesn't print the new values on new lines, but instead replaces current values with new values on respective line
            Console.Clear();

            //print info once again
            Console.WriteLine(info);

            for (int i = 0; i < options.Length; i++)
            {
                //if i equals the index value we are highlighting, print it in green color with an arrow to show that THIS is the value we are on
                if (i == index)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("> " + options[i]);
                    //reset text color back to gray
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                //else simply print the value
                else
                {
                    Console.WriteLine(options[i]);
                }
            }
        }

        public static void SelectedMenuChoice(object selected)
        {
            if (selected.ToString() == "Park")
            {
                Console.Write("Write your name:");
                string PersonName = Console.ReadLine();

                if (Api.ValidateName(PersonName).Result)
                {
                    List<Starship> starships = Api.GetStarShips().Result;
                    List<object> starshipNames = new();
                    foreach (var item in starships)
                    {
                        starshipNames.Add(item.Name);
                    }
                    ShowMenu("Choose your vehicle:", starshipNames.ToArray());
                }
                else
                {
                    Console.WriteLine("Sorry your name is not on the VIP list.");
                    Console.WriteLine("You have to leave immeately or else the security will hunt you down");
                }
            }
            else if (selected.ToString() == "Pay for parking")
            {
                Console.Write("Write your name:");
                string PersonName = Console.ReadLine();

                if (Api.ValidateName(PersonName).Result)
                {
                    //få data ifrån databasen med tid som dem anlände och vilken farkost dem hade.
                    Console.WriteLine("JA hej då...");
                    Console.WriteLine("Hoppas du inte kommer tillbaks igen");
                }
                else
                {
                    Console.WriteLine("Sorry your name is not on the VIP list.");
                    Console.WriteLine("You have to leave immeately or else the security will hunt you down");
                }
            }
        }
    }
}

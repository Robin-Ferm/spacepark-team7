using SpacePort.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort
{
    public class Menu
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

            while (key != ConsoleKey.Enter)
            {
                if (key == ConsoleKey.UpArrow && selected > 0)
                {
                    selected--;
                    HighlightMenuOption(info, options, selected);
                }
                else if (key == ConsoleKey.DownArrow && selected < options.Length - 1)
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
                Console.Clear();
                Console.WriteLine("Fill in parking details");
                Console.WriteLine();
                if (DBMethods.EmptySpaces())
                {


                    Console.Write("Write your name: ");
                    
                    string personName = Console.ReadLine();

                    if (Api.ValidateName(personName).Result)
                    {
                        if (DBMethods.AlreadyParked(personName))
                        {

                            Console.Clear();
                            Console.WriteLine("You need to pay for your parking before you can park again");
                            Program.Continue();
                        }
                        else
                        {
                            List<Starship> starships = Api.GetStarShips().Result;
                            List<object> starshipNames = new();
                            foreach (var item in starships)
                            {
                                starshipNames.Add(item.Name);
                            }

                            var spaceShip = ShowMenu("Choose your vehicle:", starshipNames.ToArray());



                            DBMethods.AddParking(personName, spaceShip.ToString());
                            Console.Clear();
                            Console.WriteLine("Your parking is done");
                            Program.Continue();
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sorry your name is not on the VIP list.");
                        Console.WriteLine("You have to leave immediately or else the security will hunt you down");
                        Program.Continue();
                    }
                }
            }
            else if (selected.ToString() == "Pay for parking")
            {
                Console.Clear();
                Console.WriteLine("Pay for your parking");
                Console.WriteLine();
                Console.Write("Write your name: ");
                string personName = Console.ReadLine();

                if (Api.ValidateName(personName).Result)
                {
                    DBMethods.AlreadyPaid(personName);
                }
                else
                {
                    Console.WriteLine("Sorry your name is not on the VIP list.");
                    Console.WriteLine("You have to leave immediately or else the security will hunt you down");
                    Program.Continue();
                }
            }
            else if (selected.ToString() == "Exit")
            {
                Console.Clear();
                Console.WriteLine("You exited the parking program.");
            }
        }
    }
}

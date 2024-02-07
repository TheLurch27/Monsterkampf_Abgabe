using System;
using System.Collections.Generic;

namespace Monsterkampf_Simulator_Abgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO HEAD OF STATE BATTLE SIMULATOR!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press any key to continue");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("In this game, you will create a battle between two heads of government from European countries.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press any key to continue");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Let's create the first head of state:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            HeadOfState monster1 = CreateHeadOfState(null, null);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Now, let's create the second head of state:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            HeadOfState monster2 = CreateHeadOfState(monster1, null);
            Console.WriteLine("");


            while (monster1.GetRace() == monster2.GetRace())
            {
                Console.Clear();
                Console.WriteLine("Please select different heads of state.");
                Console.WriteLine("Now, let's create the second head of state:");
                monster2 = CreateHeadOfState(monster1, null);
            }

            HeadOfState firstAttacker, secondAttacker;
            if (monster1.GetSpeed() >= monster2.GetSpeed())
            {
                firstAttacker = monster1;
                secondAttacker = monster2;
            }
            else
            {
                firstAttacker = monster2;
                secondAttacker = monster1;
            }

            Console.WriteLine("DING DING DING... The battle begins!");

            int rounds = 0;
            while (monster1.IsAlive() && monster2.IsAlive())
            {
                rounds++;
                firstAttacker.Attack(secondAttacker);
                if (secondAttacker.IsAlive())
                {
                    secondAttacker.Attack(firstAttacker);
                }
            }

            if (monster1.IsAlive())
            {
                Console.WriteLine($"{monster1.GetRace()} wins after {rounds} rounds!");
            }
            else
            {
                Console.WriteLine($"{monster2.GetRace()} wins after {rounds} rounds!");
            }

            Console.WriteLine("Thank you for playing THE HEAD OF STATE BATTLE SIMULATOR!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press any key to exit the game");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        static HeadOfState CreateHeadOfState(HeadOfState otherHeadOfState1, HeadOfState otherHeadOfState2)
        {
            string race;
            int hp, ap, dp, speed;

            Console.Clear();
            Console.WriteLine("Select the head of state:");

            // Available races
            List<string> availableHeadOfState = new List<string>
            {
                "Olaf Scholz (Germany)",
                "Emmanuel Macron (France)",
                "Giorgia Meloni (Italy)",
                "Aljaksandr Lukaschenko (Belarus)",
                "King Philippe (Belgium)",
                "King Frederik X (Denmark)",
                "Sauli Niinistö (Finland)",
                "Katerina Sakellaropoulou (Greece)",
                "Zoran Milanović (Croatia)",
                "Prince Hans-Adam II. (Liechtenstein)",
                "Grand Duke Henri (Luxembourg)",
                "Prince Albert II. (Monaco)",
                "King Willem-Alexander (Netherlands)",
                "King Harald V. (Norway)",
                "Alexander Van der Bellen (Austria)",
                "Andrzej Duda (Poland)",
                "Marcelo Rebelo de Sousa (Portugal)",
                "Wladimir Putin (Russia)",
                "Carl XVI. Gustaf (Sweden)",
                "Viola Amherd (Switzerland)",
                "King Felipe VI. (Spain)",
                "Petr Pavel (Czech Republic)",
                "Wolodymyr Selenskyj (Ukraine)",
                "Pope Francis (Vatican City)",
                "König Charles III. (United Kingdom)"
            };

            // Remove already selected races
            if (otherHeadOfState1 != null)
            {
                availableHeadOfState.Remove(otherHeadOfState1.GetRace());
                Console.Clear();
            }
            if (otherHeadOfState2 != null)
            {
                availableHeadOfState.Remove(otherHeadOfState2.GetRace());
                Console.Clear();
            }

            // Display available races with interactive selection
            int selectedIndex = 0;
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < availableHeadOfState.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.WriteLine(availableHeadOfState[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + availableHeadOfState.Count) % availableHeadOfState.Count;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % availableHeadOfState.Count;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            race = availableHeadOfState[selectedIndex];

            Console.Clear();
            Console.WriteLine("Enter head of state attributes:");

            Console.Write("HP (1-100): ");
            while (!int.TryParse(Console.ReadLine(), out hp) || hp < 1 || hp > 100)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a whole number between 1 and 100 for HP.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("HP (1-100): ");
            }

            Console.Write("AP (1-100): ");
            while (!int.TryParse(Console.ReadLine(), out ap) || ap < 1 || ap > 100)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a whole number between 1 and 100 for AP.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("AP (1-100): ");
            }

            Console.Write("DP (1-100): ");
            while (!int.TryParse(Console.ReadLine(), out dp) || dp < 1 || dp > 100)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a whole number between 1 and 100 for DP.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("DP (1-100): ");
            }

            Console.Write("Speed (1-100): ");
            while (!int.TryParse(Console.ReadLine(), out speed) || speed < 1 || speed > 100)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a whole number between 1 and 100 for Speed.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Speed (1-100): ");
            }

            return new HeadOfState(hp, ap, dp, speed, race);
        }
    }
}

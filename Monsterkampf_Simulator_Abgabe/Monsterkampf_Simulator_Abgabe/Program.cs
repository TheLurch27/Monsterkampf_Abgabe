namespace Monsterkampf_Simulator_Abgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Monster Battle Simulator!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press a button to continue");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("In this game, you will create two monsters and watch them fight.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press a button to continue");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Let's create the ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("first ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("monster:");
            Console.WriteLine();
            Monster monster1 = CreateMonster();
            Console.ReadKey();
            Console.Clear();

            Console.Write("Now, let's create the ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("second ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("monster:");
            Console.WriteLine();
            Monster monster2 = CreateMonster();
            Console.ReadKey();
            Console.Clear();

            while (monster1.GetRace() == monster2.GetRace())
            {
                Console.Clear();
                Console.WriteLine("Please select different races for the monsters.");
                Console.WriteLine("Now, let's create the second monster:");
                monster2 = CreateMonster();
            }

            Monster firstAttacker, secondAttacker;
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

            Console.WriteLine("The battle begins!");

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

            Console.WriteLine("Thank you for playing Monster Battle Simulator!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static Monster CreateMonster()
        {
            float hp, ap, dp, speed;
            string race;

            Console.WriteLine("Enter monster race (1 = Ork, 2 = Troll, 3 = Goblin):");
            int raceInput;
            while (!int.TryParse(Console.ReadLine(), out raceInput) || raceInput < 1 || raceInput > 3)
            {
                Console.Clear();
                Console.WriteLine("Invalid input! Please enter a number between 1 and 3 for race.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Enter monster race (1 = Ork, 2 = Troll, 3 = Goblin):");
            }

            race = raceInput == 1 ? "Ork" : raceInput == 2 ? "Troll" : "Goblin";

            Console.WriteLine("Enter monster attributes:");
            Console.Write("HP (1-100): ");
            while (!float.TryParse(Console.ReadLine(), out hp) || hp < 1 || hp > 100)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a number between 1 and 100 for HP.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Press a button to continue");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter monster attributes:");
                Console.Write("HP (1-100): ");
            }

            Console.Write("AP (1-100): ");
            while (!float.TryParse(Console.ReadLine(), out ap) || ap < 1 || ap > 100)
            {
                Console.Clear();
                Console.WriteLine("Invalid input! Please enter a number between 1 and 100 for AP.");
                Console.WriteLine("Enter monster attributes:");
                Console.Write("HP (1-100): ");
                Console.WriteLine($"Race: {race}");
                Console.Write("AP (1-100): ");
            }

            Console.Write("DP (1-100): ");
            while (!float.TryParse(Console.ReadLine(), out dp) || dp < 1 || dp > 100)
            {
                Console.Clear();
                Console.WriteLine("Invalid input! Please enter a number between 1 and 100 for DP.");
                Console.Clear();
                Console.WriteLine("Enter monster attributes:");
                Console.Write("HP (1-100): ");
                Console.WriteLine($"Race: {race}");
                Console.Write("AP (1-100): ");
                Console.WriteLine($"Race: {race}");
                Console.Write("DP (1-100): ");
            }

            Console.Write("Speed (1-100): ");
            while (!float.TryParse(Console.ReadLine(), out speed) || speed < 1 || speed > 100)
            {
                Console.Clear();
                Console.WriteLine("Invalid input! Please enter a number between 1 and 100 for Speed.");
                Console.WriteLine("Enter monster attributes:");
                Console.Write("HP (1-100): ");
                Console.WriteLine($"Race: {race}");
                Console.Write("AP (1-100): ");
                Console.WriteLine($"Race: {race}");
                Console.Write("DP (1-100): ");
                Console.WriteLine($"Race: {race}");
                Console.Write("Speed (1-100): ");
            }

            return new Monster(hp, ap, dp, speed, race);
        }
    }
}

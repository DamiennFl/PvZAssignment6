using System;
using System.Runtime.CompilerServices;

namespace PvZAssignment6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameObjectManager gameObjectManager = new GameObjectManager();
            GameEventManager gameEventManager = new GameEventManager(gameObjectManager);

            bool running = true;
            while (running)
            {
                Console.WriteLine("Plants vs Zombies Demo:");
                Console.WriteLine("1. Create Zombies");
                Console.WriteLine("2. Demo Game Play");
                Console.WriteLine("3. Display Current Zombies");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateZombies(gameObjectManager);
                        break;
                    case "2":
                        DemoGamePlay(gameObjectManager, gameEventManager);
                        break;
                    case "3":
                        DisplayZombies(gameObjectManager);
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateZombies(GameObjectManager gameObjectManager)
        {
            bool backToMenu = false;
            while (!backToMenu)
            {
                Console.WriteLine("\nCreate Zombies:");
                Console.WriteLine("1. Regular Zombie");
                Console.WriteLine("2. Cone Zombie");
                Console.WriteLine("3. Bucket Zombie");
                Console.WriteLine("4. Screen Door Zombie");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter zombie type (0-4): ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        backToMenu = true;
                        break;
                    case "1":
                        gameObjectManager.CreateZombie("Regular");
                        break;
                    case "2":
                        gameObjectManager.CreateZombie("Cone");
                        break;
                    case "3":
                        gameObjectManager.CreateZombie("Bucket");
                        break;
                    case "4":
                        gameObjectManager.CreateZombie("Screen");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        continue;
                }

                gameObjectManager.DisplayEnemies();
            }
        }

        static void DemoGamePlay(GameObjectManager gameObjectManager, GameEventManager gameEventManager)
        {
            bool backToMenu = false;
            while (!backToMenu)
            {
                if (gameObjectManager.zombieList.Count == 0)
                {
                    Console.WriteLine("No zombies to attack! Please create some zombies first.");
                    return;
                }

                Console.WriteLine("\nSelect Plant for Attack:");
                Console.WriteLine("1. Peashooter (25 damage)");
                Console.WriteLine("2. Watermelon (40 damage)");
                Console.WriteLine("3. Magnet-shroom (removes metal accessories)");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter plant type (0-3): ");

                if (int.TryParse(Console.ReadLine(), out int plantType))
                {
                    if (plantType == 0)
                    {
                        backToMenu = true;
                    }
                    else if (plantType >= 1 && plantType <= 3)
                    {
                        gameEventManager.SimulateCollisionDetection(plantType);
                        gameObjectManager.DisplayEnemies();
                    }
                    else
                    {
                        Console.WriteLine("Invalid plant type selected.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void DisplayZombies(GameObjectManager gameObjectManager)
        {
            bool backToMenu = false;
            while (!backToMenu)
            {
                gameObjectManager.DisplayEnemies();
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter 0 to go back: ");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    backToMenu = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }
}

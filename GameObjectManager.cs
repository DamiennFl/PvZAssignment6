using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvZAssignment6
{
    public class GameObjectManager : IObserver
    {
        public List<Zombie> zombieList = new List<Zombie>();
        private ZombieFactory zombieFactory = new ConcreteZombieFactory();

        public void Update(Zombie zombie)
        {
            // When an zombie dies, remove it from the list
            if (zombie.IsDead)
            {
                zombieList.Remove(zombie);
                Console.WriteLine("An zombie was removed from the game.");
            }
        }

        public void CreateZombie(string zombieType)
        {
            Zombie newZombie = null;
            switch (zombieType)
            {
                case "Regular":
                    newZombie = zombieFactory.createRegularZombie();
                    break;
                case "Cone":
                    newZombie = zombieFactory.createConeZombie();
                    break;
                case "Bucket":
                    newZombie = zombieFactory.createBucketZombie();
                    break;
                case "Screen":
                    newZombie = zombieFactory.createScreenDoorZombie();
                    break;
                default:
                    Console.WriteLine("Invalid zombie type.");
                    break;
            }

            if (newZombie != null)
            {
                AddZombie(newZombie);
            }
        }

        public void AddZombie(Zombie zombie)
        {
            zombieList.Add(zombie);
            zombie.RegisterObserver(this);
        }

        public void DisplayEnemies()
        {
            Console.WriteLine("\nCurrent Enemies:");
            if (zombieList.Count == 0)
            {
                Console.WriteLine("No enemies left!");
                return;
            }

            for (int i = 0; i < zombieList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {zombieList[i]}");
            }
            Console.WriteLine();
        }
    }
}

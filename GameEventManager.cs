using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvZAssignment6
{
    internal class GameEventManager
    {
        private GameObjectManager gameObjectManager;

        public GameEventManager(GameObjectManager gameObjectManager)
        {
            this.gameObjectManager = gameObjectManager;
        }

        public void SimulateCollisionDetection(int attack)
        {
            Zombie targetZombie = gameObjectManager.zombieList[0];

            switch (attack)
            {
                case 1:
                    this.DoDamage(attack, targetZombie);
                    break;
                case 2:
                    DoDamageFromAbove(attack, targetZombie);
                    break;
                case 3:
                    Magnetize(targetZombie);
                    break;
            }
        }

        private void DoDamage(int damage, Zombie zombie)
        {
            zombie.TakeDamage(damage);
        }

        private void DoDamageFromAbove(int damage, Zombie zombie)
        {
            zombie.TakeDamageFromAbove(damage);
        }

        private void Magnetize(Zombie zombie)
        {
            if (zombie is ZombieDecorator accessory && accessory.IsMetal)
            {
                int index = gameObjectManager.zombieList.IndexOf(zombie);
                if (index >= 0)
                {
                    gameObjectManager.zombieList[index] = new RegularZombie();
                    Zombie tempZombie = gameObjectManager.zombieList[index];
                    tempZombie.RegisterObserver(gameObjectManager);
                }
            }
        }
    }
}

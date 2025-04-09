using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvZAssignment6
{
    internal class ConcreteZombieFactory : ZombieFactory
    {
        public ConcreteZombieFactory() { }

        Zombie zombie = new RegularZombie();

        public override Zombie createRegularZombie()
        {
            return new RegularZombie();
        }

        public override Zombie createConeZombie()
        {
            return new ConeZombie(zombie);
        }
        public override Zombie createBucketZombie()
        {
            return new BucketZombie(zombie);
        }

        public override Zombie createScreenDoorZombie()
        {
            return new ScreenDoorZombie(zombie);
        }
    }
}

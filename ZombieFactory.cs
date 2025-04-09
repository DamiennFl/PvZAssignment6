using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvZAssignment6
{
    internal abstract class ZombieFactory
    {
        public abstract Zombie createRegularZombie();
        public abstract Zombie createConeZombie();
        public abstract Zombie createBucketZombie();
        public abstract Zombie createScreenDoorZombie();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvZAssignment6
{
    internal class ScreenDoorZombie : ZombieDecorator
    {
        public ScreenDoorZombie(Zombie zombie) : base(zombie, 25, true, "Screen")
        {
        }

        public override void TakeDamageFromAbove(int damage)
        {
            this.zombie.TakeDamage(damage);
        }
    }
}

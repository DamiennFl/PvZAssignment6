using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvZAssignment6
{
    internal class ConeZombie : ZombieDecorator
    {
        public ConeZombie(Zombie zombie) : base(zombie, 25, false, "Cone")
        {
        }

        public override void TakeDamageFromAbove(int damage)
        {
            this.TakeDamage(damage);
        }
    }
}

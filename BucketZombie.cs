using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PvZAssignment6
{
    internal class BucketZombie : ZombieDecorator
    {
        public BucketZombie(Zombie zombie) : base(zombie, 100, true, "Bucket")
        {
        }

        public override void TakeDamageFromAbove(int damage)
        {
            this.TakeDamage(damage);
        }

    }
}

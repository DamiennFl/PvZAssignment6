using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PvZAssignment6
{
    internal class RegularZombie : Zombie
    {

        public override int Health { get; }
        public override bool IsMetal { get; }

        public RegularZombie()
        {
            this.Health = 50;
        }

        public override void TakeDamage(int damage)
        {
            this.health -= damage;

            if (this.health <= 0)
            {
                this.Die();
            }
        }

        public override void TakeDamageFromAbove(int damage)
        {
            TakeDamage(damage);
        }

        public override void Die()
        {
            this.IsDead = true;
            NotifyObservers(this);
        }
    }
}

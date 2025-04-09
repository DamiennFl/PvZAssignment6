using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PvZAssignment6
{
    public abstract class ZombieDecorator : Zombie
    {
        protected Zombie zombie;
        protected bool isMetal;
        protected string accessoryName;

        public ZombieDecorator(Zombie zombie, int accessoryHealth, bool isMetal, string accessoryName)
        {
            this.zombie = zombie;
            this.health = accessoryHealth;
            this.isMetal = isMetal;
            this.accessoryName = accessoryName;
        }

        public override int Health
        {
            get
            {
                return this.zombie.Health + this.health;
            }
        }

        public override bool IsMetal
        {
            get
            {
                return this.isMetal;
            }
        }

        public override void TakeDamage(int damage)
        {
            if (this.health > 0)
            {
                this.health -= damage;

                if (this.health <= 0)
                {
                    int leftoverDamage = this.health * -1;
                    this.health = 0;
                    this.IsDead = true;
                    this.Die();
                    if (leftoverDamage > 0)
                    {
                        this.zombie.TakeDamage(leftoverDamage);
                    }
                }
            }
            else
            {
                this.zombie.TakeDamage(damage);
            }
        }

        public override void Die()
        {
            this.IsDead = true;
            NotifyObservers(this);
            this.zombie.Die(); // Ensure the inner zombie also dies
        }

        private class ZombieDecoratorObserver : IObserver
        {
            private ZombieDecorator decorator;

            public ZombieDecoratorObserver(ZombieDecorator decorator)
            {
                this.decorator = decorator;
            }

            public void Update(Zombie zombie)
            {
                // Forward the notification from the inner zombie
                if (zombie.IsDead)
                {
                    decorator.Die();
                }
            }
        }
    }
}

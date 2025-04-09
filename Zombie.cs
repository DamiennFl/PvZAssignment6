using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvZAssignment6
{
    public abstract class Zombie : IEntity
    {
        protected int health;
        public bool IsDead { get; protected set; } = false;

        private List<IObserver> observers = new List<IObserver>();

        public abstract int Health { get; }
        public abstract bool IsMetal { get; }
        public abstract void TakeDamage(int damage);
        public abstract void TakeDamageFromAbove(int damage);
        public abstract void Die();

        public void RegisterObserver(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void UnregisterObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(Zombie zombie)
        {
            foreach (var observer in observers)
            {
                observer.Update(zombie);
            }
        }
    }
}

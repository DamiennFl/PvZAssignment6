using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvZAssignment6
{
    internal interface IEntity
    {
        void RegisterObserver(IObserver observer);
        void UnregisterObserver(IObserver observer);
        void NotifyObservers(Zombie zombie);
    }
}

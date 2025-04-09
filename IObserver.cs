using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvZAssignment6
{
    public interface IObserver
    {
        public void Update(Zombie zombie);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Core.States.Interfaces
{
    public interface IPriorityState
    {
        IPriorityState NA();
        IPriorityState Low();
        IPriorityState Medium();
        IPriorityState High();
        IPriorityState Emergency();
    }
}

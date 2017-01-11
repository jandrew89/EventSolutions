using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSolutions.Services.States
{
    public interface IAssignState
    {
        IAssignState Freeze();
        IAssignState Active();
        IAssignState Completed();
    }
}

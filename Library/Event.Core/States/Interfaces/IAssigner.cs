using Assignment.Repository.Models;
using Event.Core.States.Interfaces;
using System;

namespace Event.Core.States.Interfaces
{
    public interface IAssigner
    {
        string Name { get; set; }
        string Description { get; set; }
        DateTime AssignDateTime { get; set; }
        Employee _employee { get; }
        Assignment.Repository.Models.Assignment _assignment { get; }
        void Change(IStatusState State);
        IStatusState State { get; }

    }
}
using System;
using Assignment.Repository.DataModel;
using Event.Core.Factories.Interfaces;
using Event.Core.Repositories.Interfaces;
using Event.Core.States.Interfaces;
using Event.Data.Repositories;

namespace Event.Data.States.Status
{
    public class CompletedState : IStatusState
    {
        private IAssignmentRepository _context;
        public CompletedState()
        {
            _context = new AssignmentRepository(new AssignmentDbContext());
        }

        public IStatusState UpdateAssignment(IAssigner assigner)
        {
            _context.UpdateAssignment(assigner._assignment, Assignment.Repository.Models.Enums.Status.Completed);
            assigner._assignment.Status = Assignment.Repository.Models.Enums.Status.Completed;
            return this;
        }

        public IStatusState UpdateUserAssignment(IAssigner assigner)
        {
            _context.UnAssign(assigner._assignment);
            return this;
        }
    }
}

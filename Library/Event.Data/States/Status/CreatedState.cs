using Event.Core.States.Interfaces;
using System;
using Event.Core.Factories.Interfaces;
using Event.Core.Repositories.Interfaces;
using Event.Data.Repositories;
using Assignment.Repository.DataModel;

namespace Event.Data.States.Status
{
    public class CreatedState : IStatusState
    {
        private IAssignmentRepository _context;
        public CreatedState()
        {
            _context = new AssignmentRepository(new AssignmentDbContext());
        }
        public IStatusState UpdateAssignment(IAssigner assigner)
        {
            _context.UpdateAssignment(assigner._assignment, Assignment.Repository.Models.Enums.Status.Created);
            assigner._assignment.Status = Assignment.Repository.Models.Enums.Status.Created;
            return this;
        }

        public IStatusState UpdateUserAssignment(IAssigner assigner)
        {

            _context.UnAssign(assigner._assignment);
            return this;
        }
    }
}

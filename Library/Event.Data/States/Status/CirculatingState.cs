using Event.Core.States.Interfaces;
using Event.Core.Factories.Interfaces;
using Event.Core.Repositories.Interfaces;
using Event.Data.Repositories;
using Assignment.Repository.DataModel;

namespace Event.Data.States.Status
{
    public class CirculatingState : IStatusState
    {

        private IAssignmentRepository _context;

        public CirculatingState()
        {
            _context = new AssignmentRepository(new AssignmentDbContext());
        }
        public IStatusState UpdateAssignment(IAssigner assigner)
        {
            _context.UpdateAssignment(assigner._assignment, Assignment.Repository.Models.Enums.Status.Circulating);
            assigner._assignment.Status = Assignment.Repository.Models.Enums.Status.Circulating;
            return this;
        }

        public IStatusState UpdateUserAssignment(IAssigner assigner)
        {
            _context.UnAssign(assigner._assignment);
            return this;
        }
    }
}

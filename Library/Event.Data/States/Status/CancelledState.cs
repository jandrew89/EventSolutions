using Event.Core.States.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Repository.Models.Enums;
using Event.Core.Factories.Interfaces;
using Event.Core.Repositories.Interfaces;
using Event.Data.Repositories;
using Assignment.Repository.DataModel;

namespace Event.Data.States.Status
{
    public class CancelledState : IStatusState
    {
        private IAssignmentRepository _context;
        public CancelledState()
        {
            _context = new AssignmentRepository(new AssignmentDbContext());
        }

        public IStatusState UpdateAssignment(IAssigner assigner)
        {
            _context.UpdateAssignment(assigner._assignment, Assignment.Repository.Models.Enums.Status.Cancelled);
            assigner._assignment.Status = Assignment.Repository.Models.Enums.Status.Cancelled;
            return this;
        }

        public IStatusState UpdateUserAssignment(IAssigner assigner)
        {
            _context.UnAssign(assigner._assignment);
            return this;
        }
    }
}

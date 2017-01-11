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
    public class RejectedState : IStatusState
    {
        private IAssignmentRepository _context;

        public RejectedState()
        {
            
            _context = new AssignmentRepository(new AssignmentDbContext());
        }

        public IStatusState UpdateAssignment(IAssigner assigner)
        {
            _context.UpdateAssignment(assigner._assignment, Assignment.Repository.Models.Enums.Status.Rejected);
            assigner._assignment.Status = Assignment.Repository.Models.Enums.Status.Rejected;
            return this;
        }

        public IStatusState UpdateUserAssignment(IAssigner assigner)
        {
            _context.UnAssign(assigner._assignment);
            //_context.Reassignment(assigner._assignment, assigner._employee, assigner.Description, Priority.Low, Assignment.Repository.Models.Enums.Status.Rejected);
            return this;
        }

    }
}

using Assignment.Repository.Models;
using Event.Core.Factories.Interfaces;
using Event.Core.States;
using Event.Core.States.Interfaces;
using Event.Data.States.Status;
using System;

namespace Event.Data.States
{
    public class Assigner : IAssigner
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AssignDateTime { get; set; }
        public Employee _employee { get; private set; }
        public Assignment.Repository.Models.Assignment _assignment { get; private set; }
        public IStatusState State { get; private set; }

        public Assigner(Assignment.Repository.Models.Enums.Status status, 
            Employee employee, 
            Assignment.Repository.Models.Assignment assignment)
        {
            this._employee = employee;
            this._assignment = assignment;

            if (status == Assignment.Repository.Models.Enums.Status.Cancelled)
                this.State = new CancelledState();

            if (status == Assignment.Repository.Models.Enums.Status.Rejected)
                this.State = new RejectedState();

            if (status == Assignment.Repository.Models.Enums.Status.Created)
                this.State = new CreatedState();

            if (status == Assignment.Repository.Models.Enums.Status.Circulating)
                this.State = new CirculatingState();

            if (status == Assignment.Repository.Models.Enums.Status.Completed)
                this.State = new CompletedState();
        }

        public void UpdateAssignment()
        { 
            this.State.UpdateAssignment(this);
        }

        public void UpdateUserAssignment()
        {
            this.State.UpdateUserAssignment(this);
        }

        public void Change(IStatusState state) =>
            this.State = state;

        public static Assignment.Repository.Models.Assignment CreateAssignmentOld(
            Assignment.Repository.Models.Assignment assignment,
            DateTime DateOfCompletion)
        {
            var createAssignment = new Assignment.Repository.Models.Assignment()
            {
                AssignmentId = Guid.NewGuid(),
                Description = assignment.Description,
                Name = assignment.Name,
                Status = Assignment.Repository.Models.Enums.Status.Created,
                CompletedDate = DateOfCompletion,
                Requests = assignment.Requests
            };

            return createAssignment;
        }

    }
}

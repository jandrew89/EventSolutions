using Assignment.Repository.Models;
using EventSolutions.Services.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EventSolutions.ViewModels
{
    public class CompleteTaskViewModel
    {
        [Required]
        public Assignment.Repository.Models.Assignment Assignment { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public UserAssignment UserAssignment { get; set; }

        public CompleteTaskViewModel()
        {

        }

        public static IEnumerable<CompleteTaskViewModel> ManageAssignmentViewModel
            (IEnumerable<Assignment.Repository.Models.Assignment> assignments, IEnumerable<UserAssignment> userAssignments)
        {
            return from assignment in assignments
                   join userAssignment in userAssignments.Where(ua => ua.IsCompleted == false)
                   on assignment.AssignmentId equals userAssignment.Assignment.AssignmentId
                   select new CompleteTaskViewModel
                   {
                       Assignment = assignment,
                       Employee = userAssignment.Employee,
                       UserAssignment = userAssignment
                   };
        }


        public static IEnumerable<CompleteTaskViewModel> TrackerViewModel(IEnumerable<UserAssignment> userAssignments) =>
            userAssignments.Select(ua => new CompleteTaskViewModel { Assignment = ua.Assignment, Employee = ua.Employee, UserAssignment = ua });
    }
}

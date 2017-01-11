using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Repository.Models;
using Assignment.Repository.Models.Enums;
using User.Repository.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventSolutions.ViewModels
{
    public class AssignmentViewModel
    {
        public Assignment.Repository.Models.Assignment Assignment { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public string Comments { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public bool IsCompleted { get; private set; }
        public DateTime DateCompleted { get; private set; }
        public TimeSpan TimeSpan { get; private set; }
        public IEnumerable<SelectListItem> Employees { get; set; }

        public AssignmentViewModel(Assignment.Repository.Models.Assignment assignment)
        {
            this.Assignment = assignment;
        }

        public AssignmentViewModel()
        {

        }

        public static UserAssignment UserAssignmentCreated(AssignmentViewModel Assignment)
        {
           
            var userAssignment = new UserAssignment()
            {
                Assignment = Assignment.Assignment,
                IsCompleted = false,
            };

            return userAssignment;
            
        }

        public static UserAssignment UserAssignmentCompleted(AssignmentViewModel Assignment)
        {
            var userAssignment = new UserAssignment()
            {
                Assignment = Assignment.Assignment,
                Response = Assignment.Comments,
                IsCompleted = true,
            };

            return userAssignment;

        }

        
    }
}

using System;
using Assignment.Repository.Models.Enums;

namespace Assignment.Repository.Models
{
    public class UserAssignment
    {
        public int Id { get; set; }
        public Assignment Assignment { get; set; }
        public Employee Employee { get; set; }
        public bool IsCompleted { get; set; }
        public string Response { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public DateTime DateOfAssignment { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }

    }
}

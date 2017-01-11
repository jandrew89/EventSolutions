using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSolutions.Models
{
    public class AssignmentDto
    {
        public string AssignmentId { get; set; }
        public int EmployeeId { get; set; }
        public string Comments { get; set; }
    }
}

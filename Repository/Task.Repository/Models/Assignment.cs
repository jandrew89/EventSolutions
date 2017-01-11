using Assignment.Repository.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository.Models
{
    public class Assignment
    {
        public Guid AssignmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requests { get; set; }
        public Status Status { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}

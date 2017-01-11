using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Events.Repository.Models;

namespace Events.Repository.Models
{
    public class Attendance
    {

        [Key]
        [Column(Order = 1)]
        public int EventId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }

        public Event Events { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository.Models
{
    public class Notification
    {
        [Key]
        [Column(Order = 1)]
        public int UserAssignmentId { get; private set; }

        public UserAssignment UserAssignment { get; private set; }

        public bool IsRead { get; private set; }

        protected Notification()
        {

        }

        public Notification(UserAssignment userAssignment)
        {
            if (userAssignment == null)
                throw new ArgumentNullException("User Assignment");

            this.UserAssignment = userAssignment;
        }

        public void Read()
        {
            IsRead = true;
        }
    }
}

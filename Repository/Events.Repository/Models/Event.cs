using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repository.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public bool IsCanceled { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }   

        [Required]
        public Profile Artist { get; set; }

        [Required]
        public byte GenreId { get; set; }
    }
}

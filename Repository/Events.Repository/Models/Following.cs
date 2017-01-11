using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.Repository.Models
{
    public class Following
    {
        //Add required
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }


        [Key]
        [Column(Order = 2)]
        public int ArtistId { get; set; }

        public Profile Artist { get; set; }

    }
}

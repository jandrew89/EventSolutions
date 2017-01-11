using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventSolutions.ViewModels
{
    public class FeedBackViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Phone]
        public int Phone { get; set; }

        [Required]
        public string Message { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventSolutions.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Role { get; set; }
        public List<SelectListItem> Roles { get; set; }

        [HiddenInput]
        public string RedirectUrl { get; set; }
    }
}

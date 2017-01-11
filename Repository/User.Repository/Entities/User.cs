using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace User.Repository.Entities
{
    public class User
    {
        [Key]
        public string Subject { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public IList<UserClaim> UserClaims { get; set; }
        public IList<UserLogin> UserLogins { get; set; }
    }
}
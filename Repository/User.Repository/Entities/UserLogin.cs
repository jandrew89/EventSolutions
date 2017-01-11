using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace User.Repository.Entities
{
    public class UserLogin
    {
        [Key]
        public string Subject { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
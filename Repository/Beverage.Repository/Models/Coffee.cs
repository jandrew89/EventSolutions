using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beverage.Repository.Models
{
    public class Coffee
    {
        [Key]
        public int Id { get; set; }
        public int CoffeeType { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string Region { get; set; }
        public string Acidity { get; set; }
        public string Body { get; set; }
        public string Elevation { get; set; }
        public string Variental { get; set; }
        [Required]
        public bool Decaf { get; set; }
        [Required]
        public bool SignOff { get; set; }
    }
}

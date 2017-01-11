using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beverage.Repository.Models
{
    public class Beverages
    {
        [Key]
        public int Id { get; set; }
        public int CoffeeId { get; set; }
        public int TeaId { get; set; }
    }
}

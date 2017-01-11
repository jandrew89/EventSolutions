using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beverage.Repository.Models
{
    public class Tea
    {
        public int Id { get; set; }
        public string BrewingMethod { get; set; }
        public bool Caffinated { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string Sourced { get; set; }
        public int TeaType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository.Models
{
    public class OrderSummary
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public OrderProduct Product { get; set; }
        public int Quantity { get; set; }
    }
}

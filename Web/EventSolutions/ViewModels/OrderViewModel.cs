using Assignment.Repository.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventSolutions.ViewModels
{
    public class OrderViewModel
    {
        public Customer Customer { get; private set; }
        public Order Order { get; set; }
        public OrderSummary OrderSummary { get; set; }
        public IEnumerable<OrderProduct> OrderProducts { get; set; }
        public string FullName { get { return this.Customer.FirstName + " " + this.Customer.LastName; }}
        public OrderViewModel(Customer customer)
        {
            this.Customer = customer;
        }

    }
}

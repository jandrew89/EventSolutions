using Assignment.Repository.Models;
using Assignment.Repository.Models.Enums;
using System.Collections.Generic;

namespace Event.Core.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Customer> GetListOfCustomers();
        Customer GetCustomerById(int id);
        IEnumerable<OrderProduct> GetOrderProducts();
        void AddOrder(Order order);
        void Commit();
    }
}

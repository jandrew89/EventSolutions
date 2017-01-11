using Assignment.Repository.DataModel;
using Assignment.Repository.Models;
using Assignment.Repository.Models.Enums;
using Event.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Event.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AssignmentDbContext _context;

        public OrderRepository(AssignmentDbContext context)
        {
            _context = context;
        }

        public OrderRepository()
        {
            _context = new AssignmentDbContext();
        }

        public IEnumerable<Customer> GetListOfCustomers() =>
            _context.Customers.ToList();

        public Customer GetCustomerById(int id) =>
            _context.Customers.Single(c => c.Id == id);

       
        public void AddOrder(Order order)
        {
            
            if (order == null)
                throw new ArgumentNullException();

            _context.Orders.Add(order);
            this.Commit();
        }

        public void Commit() =>
           _context.SaveChanges();

        public IEnumerable<OrderProduct> GetOrderProducts() =>
            _context.OrderProducts.ToList();
    }
}

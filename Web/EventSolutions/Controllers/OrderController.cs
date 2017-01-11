using Assignment.Repository.Models;
using Event.Core.Repositories.Interfaces;
using EventSolutions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Repository;

namespace EventSolutions.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IAssignmentRepository _assignmentRepository;

        public OrderController(IUserRepository UserRepository,
                IOrderRepository orderRepository, IAssignmentRepository assignmentRepository)
        {
            _userRepository = UserRepository;
            _orderRepository = orderRepository;
            _assignmentRepository = assignmentRepository;
        }

        public IActionResult PlaceOrder(int id)
        {
            var customer = _orderRepository.GetCustomerById(id);
            var viewmodel = new OrderViewModel(customer);
            
            viewmodel.OrderProducts = _orderRepository.GetOrderProducts();
            return View(viewmodel);
        }
    }
}

using Event.Core.Repositories.Interfaces;
using Event.Data.States;
using EventSolutions.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Repository;

namespace EventSolutions.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IAssignmentRepository _assignmentRepository;

        public CustomerController(IUserRepository UserRepository,
                IOrderRepository orderRepository, IAssignmentRepository assignmentRepository)
        {
            _userRepository = UserRepository;
            _orderRepository = orderRepository;
            _assignmentRepository = assignmentRepository;
        }

        public IActionResult Index()
        {
            var customers = _orderRepository.GetListOfCustomers();
            return View(customers);
        }
    }
}

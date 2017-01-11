using Assignment.Repository.Models.Enums;
using Event.Core.Repositories.Interfaces;
using Event.Core.States.Interfaces;
using Event.Data.States;
using EventSolutions.Services;
using EventSolutions.Services.Extensions;
using EventSolutions.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Repository;

namespace EventSolutions.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageService _messageService;

        public AssignmentController(IAssignmentRepository AssignmentRepository,
               IUserRepository UserRepository,
               IMessageService MessageService,
               IOrderRepository OrderRepository)
        {
            _orderRepository = OrderRepository;
            _messageService = MessageService;
            _userRepository = UserRepository;
            _assignmentRepository = AssignmentRepository;
        }

        public IActionResult Index()
        {
            var assignments = _assignmentRepository.GetAssignmentList();
            var userAssignments = _assignmentRepository.GetUserAssignments();


            var completedViewModel = CompleteTaskViewModel.ManageAssignmentViewModel(assignments, userAssignments);

            return View(completedViewModel);
        }

        [Authorize]
        public IActionResult Complete(string id)
        {
            var currentUserAssignment = _assignmentRepository.GetAssignmentById(id);
            var assignmentViewModel = new AssignmentViewModel(currentUserAssignment);

            return PartialView("_Complete", assignmentViewModel);
        }

        [HttpPost]
        public IActionResult Complete(string id, [Bind("Comments")]AssignmentViewModel assignmentViewModel)
        {
            var currentAssignment = _assignmentRepository.GetAssignmentById(id);
            if (currentAssignment == null)
            {
                return NotFound();
            }

            //_assignmentRepository.Completed(currentAssignment, assignmentViewModel.Comments);
            return RedirectToAction("Tracker", "Assignment", new { id= id });
        }

        [Authorize]
        public IActionResult Assign(string id)
        {
            var employeeList = _assignmentRepository.GetEmployeeList();
            var currentUserAssignment = _assignmentRepository.GetAssignmentById(id);
            
            var assignmentViewModel = new AssignmentViewModel(currentUserAssignment);
            assignmentViewModel.Employees = employeeList.SelectEmployeesItems(0);

            return PartialView("_Assign", assignmentViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Assign(string id, [Bind("EmployeeId,Comments,Status,Priority")]AssignmentViewModel assignmentViewModel)
        {
            var employee = _assignmentRepository.GetEmployeeById(assignmentViewModel.EmployeeId);
            var assignment = _assignmentRepository.GetAssignmentById(id);

            //STATE DESIGN
            IAssigner assigner = new Assigner(assignmentViewModel.Status, employee, assignment);
            assigner.Description = assignmentViewModel.Comments;
            assigner.State.UpdateAssignment(assigner);
            
            //FACTORY DESIGN
            _assignmentRepository.UnAssign(assignment);
            var userAssignment = _assignmentRepository.Reassignment(assigner._assignment, assigner._employee, assigner.Description, assignmentViewModel.Priority, assignmentViewModel.Status);
            _assignmentRepository.UpdateNotifications(userAssignment);
            
            _messageService.SendEmailAsync(employee.Email, $"Task Assigment {assignment.Name}", assignmentViewModel.Comments);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Tracker(string id)
        {
            var userAssignments = _assignmentRepository.GetUserAssignmentsWithAssignmentId(id);
            var completeViewModel = CompleteTaskViewModel.TrackerViewModel(userAssignments);
            
            return View("Tracker", completeViewModel);
        }

        public IActionResult Editor(string id)
        {
            var assignment = _assignmentRepository.GetAssignmentById(id);

            return PartialView("_Editor", assignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editor([Bind("AssignmentId,Description,Name")]Assignment.Repository.Models.Assignment assigner)
        {
            if (ModelState.IsValid)
            {

            }

            return View("Index");
        }

        [Authorize]
        public IActionResult CreateTask()
        {
            var completeViewModel = new CompleteTaskViewModel();
            return View(completeViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateTask(CompleteTaskViewModel completeViewModel)
        {

            var employee = _assignmentRepository.GetEmployeeByRole(completeViewModel.UserAssignment.Employee.Role);
            //Factory methods
            var newAssignment = Assigner.CreateAssignmentOld(completeViewModel.Assignment, completeViewModel.Assignment.CompletedDate);
           
            _assignmentRepository.AddAssignment(newAssignment);

            //CREATE USERASSIGNMENT
            var userAssignment = _assignmentRepository.CreateUserAssignment(newAssignment, employee, completeViewModel.Assignment.CompletedDate, completeViewModel.UserAssignment.Priority, completeViewModel.UserAssignment.Response);

            if (userAssignment.Priority == Priority.Emergency)
                _messageService.SendSmsAsync("2608200003", userAssignment.Response);


            return RedirectToAction("Index");
        }
    }
}

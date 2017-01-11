using Event.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Assignment.Repository.DataModel;
using Assignment.Repository.Models;
using Assignment.Repository.Models.Enums;

namespace Event.Data.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly AssignmentDbContext _context;

        public AssignmentRepository(AssignmentDbContext context)
        {
            _context = context;
        }

        public AssignmentRepository()
        {
            _context = new AssignmentDbContext();
        }

        public IEnumerable<Assignment.Repository.Models.Assignment> GetAssignmentList() =>
            _context.Assignments.ToList();

        public IEnumerable<Employee> GetEmployeeList() =>
            _context.Employees.ToList();

        public IEnumerable<UserAssignment> GetUserAssignments() =>
          _context.UserAssignment.Include(ua => ua.Employee).Include(ua => ua.Assignment).ToList();

        public IEnumerable<UserAssignment> GetUserAssignmentsWithAssignmentId(string id) =>
         _context.UserAssignment
            .Include(ua => ua.Employee)
            .Include(ua => ua.Assignment)
            .Where(ua => ua.Assignment.AssignmentId.ToString() == id)
            .ToList();

        public Employee GetEmployeeByRole(Roles role) =>
           _context.Employees.Single(e => e.Role == role);


        public void AddAssignment(Assignment.Repository.Models.Assignment assignment)
        {
            if (assignment == null)
                throw new ArgumentNullException();

            _context.Assignments.Add(assignment);
            this.Commit();
        }

        public Assignment.Repository.Models.Assignment GetAssignmentById(string id) =>
            _context.Assignments.First(t => t.AssignmentId.ToString() == id);

        public Employee GetEmployeeById(int id) =>
            _context.Employees.Single(e => e.Id == id);

        public Employee GetCurrentEmployeeUserAssignment(string userAssignmentId) =>
            _context.UserAssignment
            .Include(ua => ua.Employee)
            .Include(ua => ua.Assignment)
            .First(us => us.Assignment.AssignmentId.ToString() == userAssignmentId && us.IsCompleted == false)
            .Employee;
       
        public UserAssignment Reassignment(Assignment.Repository.Models.Assignment assignment, Employee employee, string response, Priority priority , Status status)
        {

            var newUserAssignment = new UserAssignment {
                Assignment = assignment,
                DateOfAssignment = DateTime.Now,
                DateOfCompletion = DateTime.Now,
                IsCompleted = false,
                Response = response,
                Priority = priority,
                Status = status
            };

            _context.UserAssignment.Add(newUserAssignment);
            _context.Employees.Attach(employee);
            newUserAssignment.Employee = employee;
            this.Commit();

            return newUserAssignment;
        }

        public UserAssignment CreateUserAssignment(Assignment.Repository.Models.Assignment assignment, 
            Employee employee, DateTime dateOfCompletion, Priority priority, string requests)
        {
            var userAssignment = new UserAssignment
            {
                Assignment = assignment,
                DateOfAssignment = DateTime.Now,
                DateOfCompletion = dateOfCompletion,
                IsCompleted = false,
                Priority = priority,
                Status = Status.Created
            };


            _context.UserAssignment.Add(userAssignment);
            _context.Employees.Attach(employee);
            userAssignment.Employee = employee;
            this.Commit();            

            return userAssignment;    
        }

        public void UpdateAssignment(Assignment.Repository.Models.Assignment assignment, Status status)
        {
            var currentAssignment = _context.Assignments.SingleOrDefault(a => a.AssignmentId == assignment.AssignmentId);
            currentAssignment.Status = status;
            currentAssignment.CompletedDate = DateTime.Now;
            _context.SaveChanges();
        }

        public void UnAssign(Assignment.Repository.Models.Assignment assignment)
        {
            var userAssignment = _context.UserAssignment
                .Include(ua => ua.Employee)
                .Single(a => a.Assignment.AssignmentId == assignment.AssignmentId && a.IsCompleted == false);
            userAssignment.IsCompleted = true;

            this.Commit();

        }

        public void UpdateNotifications(UserAssignment userAssignment)
        {
            var notification = new Notification(userAssignment);
            _context.Notifications.Add(notification);
            this.Commit();
        }

        public void Commit() =>
            _context.SaveChanges();
    }
}

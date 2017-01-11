using System;
using System.Collections.Generic;
using Assignment.Repository.Models;
using Assignment.Repository.Models.Enums;

namespace Event.Core.Repositories.Interfaces
{
    public interface IAssignmentRepository
    {
        IEnumerable<Assignment.Repository.Models.Assignment> GetAssignmentList();
        IEnumerable<Employee> GetEmployeeList();
        IEnumerable<UserAssignment> GetUserAssignments();
        IEnumerable<UserAssignment> GetUserAssignmentsWithAssignmentId(string id);
        Assignment.Repository.Models.Assignment GetAssignmentById(string id);
        UserAssignment CreateUserAssignment(Assignment.Repository.Models.Assignment assignment, Employee employee, DateTime dateOfCompletion, Priority priority, string requests);
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByRole(Roles role);
        Employee GetCurrentEmployeeUserAssignment(string userAssignmentId);
        UserAssignment Reassignment(Assignment.Repository.Models.Assignment assignment, Employee employee, string response, Priority priority, Status status);
        void UpdateAssignment(Assignment.Repository.Models.Assignment assignment, Status status);
        void UpdateNotifications(UserAssignment userAssignment);
        void AddAssignment(Assignment.Repository.Models.Assignment assignment);
        void UnAssign(Assignment.Repository.Models.Assignment pastUserAssignment);
        void Commit();
        
    }
}

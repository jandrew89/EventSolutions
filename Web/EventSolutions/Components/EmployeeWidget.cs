using Assignment.Repository.Models.Enums;
using Event.Core.Repositories.Interfaces;
using EventSolutions.Services.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSolutions.Components
{
    public class EmployeeWidget : ViewComponent
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public EmployeeWidget(IAssignmentRepository assignmentRepository)
        {
            this._assignmentRepository = assignmentRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var employees = _assignmentRepository.GetEmployeeList();
            return View(employees.Where(e => e.Role != Roles.SalesTeam && e.Role != Roles.TempTeam).DistintBy(e => e.Role));
        }
    }
}

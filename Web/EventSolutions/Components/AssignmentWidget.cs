using Event.Core.Repositories.Interfaces;
using EventSolutions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSolutions.Components
{
    public class AssignmentWidget : ViewComponent
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentWidget(IAssignmentRepository assignmentRepository)
        {
            this._assignmentRepository = assignmentRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var assignments = _assignmentRepository.GetAssignmentList();
            var userAssignments = _assignmentRepository.GetUserAssignments();


            var completedViewModel = CompleteTaskViewModel.ManageAssignmentViewModel(assignments, userAssignments);
            return View(completedViewModel);
        }
    }
}

using Event.Core.Repositories.Interfaces;
using EventSolutions.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSolutions.Controllers.Api
{
    [Route("api")]
    public class AssignmentController : Controller
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentController(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        [HttpGet("assignments")]
        public IActionResult GetAssignments()
        {
            return Ok(_assignmentRepository.GetAssignmentList());
        }

        [HttpGet("userassignments")]
        public IActionResult GetUserAssignments()
        {
            return Ok(_assignmentRepository.GetUserAssignments());
        }

        [HttpGet("userassignments/intransit")]
        public IActionResult GetUserAssignmentsInTransit()
        {
            return Ok(_assignmentRepository.GetUserAssignments()
                .Where(ua => ua.IsCompleted == false));
        }

    }
}

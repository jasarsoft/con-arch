using ConfArch.Data.Models;
using ConfArch.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConfArch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttendeeController : Controller
    {
        private readonly IAttendeeRepository repo;

        public AttendeeController(IAttendeeRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost("{conferenceId}/{name}")]
        [Authorize(Policy = "PostAttendee")]
        public IActionResult Post(int conferenceId, string name)
        {
            var attendee = repo.Add(
                new AttendeeModel { ConferenceId = conferenceId, Name = name });
            return StatusCode(201);
        }
    }
}

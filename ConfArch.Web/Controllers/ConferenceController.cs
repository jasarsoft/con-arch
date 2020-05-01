using System.Threading.Tasks;
using ConfArch.Data.Models;
using ConfArch.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConfArch.Web.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConfArchApiService _api;

        public ConferenceController(IConfArchApiService api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Organizer - Conference Overview";
            return View(await _api.GetAllConferences());
        }

        [Authorize(Policy = "CanAddConference")]
        public IActionResult Add()
        {
            ViewBag.Title = "Organizer - Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        [Authorize(Policy = "CanAddConference")]
        public async Task<IActionResult> Add(ConferenceModel model)
        {
            if (ModelState.IsValid)
                await _api.AddConference(model);

            return RedirectToAction("Index");
        }
    }
}

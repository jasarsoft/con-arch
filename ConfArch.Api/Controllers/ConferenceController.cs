using System.Collections.Generic;
using System.Threading.Tasks;
using ConfArch.Data.Models;
using ConfArch.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConfArch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConferenceController : Controller
    {
        private readonly IConferenceRepository repo;

        public ConferenceController(IConferenceRepository repo)
        {

            this.repo = repo;
        }

        public async Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return await repo.GetAll();
        }

        [HttpPost]
        public void Add(ConferenceModel conference)
        {
            repo.Add(conference);
        }
    }
}

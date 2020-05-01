using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfArch.Data.Models;
using ConfArch.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConfArch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProposalController
    {
        private readonly IProposalRepository repo;

        public ProposalController(IProposalRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("GetAll/{conferenceId}")]
        public async Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return await repo.GetAllForConference(conferenceId);
        }

        [HttpPost("Add")]
        public void Add([FromBody]ProposalModel model)
        {
            repo.Add(model);
        }

        [HttpGet("Approve/{proposalId}")]
        public async Task<ProposalModel> Approve(int proposalId)
        {
            return await repo.Approve(proposalId);
        }
    }
}

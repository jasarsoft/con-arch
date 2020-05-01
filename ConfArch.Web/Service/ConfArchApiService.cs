using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConfArch.Data.Models;

namespace ConfArch.Web.Services
{
    public class ConfArchApiService : IConfArchApiService
    {
        private readonly HttpClient client;

        public ConfArchApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<AttendeeModel> AddAttendee(AttendeeModel attendee)
        {
            var response = await
                client.PostAsJsonAsync("/Attendee/Add", attendee);
            return await response.ReadContentAs<AttendeeModel>(); ;
        }

        public async Task<IEnumerable<ConferenceModel>> GetAllConferences()
        {
            var response = await client.GetAsync("/Conference");
            return await response.ReadContentAs<List<ConferenceModel>>();
        }

        public async Task AddConference(ConferenceModel model)
        {
            await client.PostAsJsonAsync("/Conference", model);
        }

        public async Task<IEnumerable<ProposalModel>> GetAllProposalsForConference(int conferenceId)
        {
            var response = await client.GetAsync($"/Proposal/GetAll/{conferenceId}");
            return await response.ReadContentAs<List<ProposalModel>>();
        }

        public async Task AddProposal(ProposalModel model)
        {
            await client.PostAsJsonAsync("/Proposal/Add/", model);
        }

        public async Task<ProposalModel> ApproveProposal(int proposalId)
        {
            var response = await client.GetAsync($"/Proposal/Approve/{proposalId}");
            return await response.ReadContentAs<ProposalModel>();
        }
    }
}

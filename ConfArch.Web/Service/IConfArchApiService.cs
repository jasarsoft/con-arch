using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfArch.Data.Models;

namespace ConfArch.Web.Services
{
    public interface IConfArchApiService
    {
        Task<AttendeeModel> AddAttendee(AttendeeModel attendee);
        Task AddConference(ConferenceModel model);
        Task AddProposal(ProposalModel model);
        Task<ProposalModel> ApproveProposal(int proposalId);
        Task<IEnumerable<ConferenceModel>> GetAllConferences();
        Task<IEnumerable<ProposalModel>> GetAllProposalsForConference(int conferenceId);
    }
}

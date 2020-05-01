using System.Threading.Tasks;
using ConfArch.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConfArch.Web.Authorization
{
    public class ProposalApprovedAuthorizationHandler :
        AuthorizationHandler<ProposalRequirement, ProposalModel>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ProposalRequirement requirement,
            ProposalModel resource)
        {
            if (!resource.Approved)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}

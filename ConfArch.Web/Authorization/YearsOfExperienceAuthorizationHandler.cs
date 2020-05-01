using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ConfArch.Web.Authorization
{
    public class YearsOfExperienceAuthorizationHandler :
        AuthorizationHandler<YearsOfExperienceRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            YearsOfExperienceRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "CareerStarted" &&
                c.Issuer == "https://localhost:5000"))
            {
                return Task.CompletedTask;
            }

            var careerStarted = DateTimeOffset.Parse(
                context.User.FindFirst(c => c.Type == "CareerStarted"
                    && c.Issuer == "https://localhost:5000").Value
            );

            var yearsOfExperience =
                Math.Round((DateTimeOffset.Now - careerStarted).TotalDays / 365);

            if (yearsOfExperience >= requirement.YearsOfExperienceRequired)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}

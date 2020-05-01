using Microsoft.AspNetCore.Authorization;

namespace ConfArch.Web.Authorization
{
    public class YearsOfExperienceRequirement : IAuthorizationRequirement
    {
        public YearsOfExperienceRequirement(int yearsOfExperienceRequired)
        {
            YearsOfExperienceRequired = yearsOfExperienceRequired;
        }
        public int YearsOfExperienceRequired { get; set; }
    }
}

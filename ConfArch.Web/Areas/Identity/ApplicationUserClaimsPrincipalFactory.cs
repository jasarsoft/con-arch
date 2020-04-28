using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ConfArch.Web.Areas.Identity
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> options) 
            : base(userManager, options)
        {
            
        }

        protected override async Task<ClaimsIdentity>  GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await  base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("CareerStarted", user.CareerStartedDate.ToShortDateString()));
            identity.AddClaim(new Claim("FullName", user.FullName));

            return identity;
        }
    }
}

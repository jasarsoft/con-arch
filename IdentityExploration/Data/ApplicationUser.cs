﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityExploration.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData] 
        public DateTime CareerStart { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace djanak.Infrastructure.Identity
{
    /// <summary>
    /// Our Role class which can be modified
    /// </summary>
    public class Role : IdentityRole<int>
    {
        public Role(string role) : base(role)
        {
        }

        public Role() : base()
        {
        }
    }
}

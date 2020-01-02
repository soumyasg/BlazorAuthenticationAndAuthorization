using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BocesModule.Shared
{
    public static class Policies
    {
        public const string CanManageCoSerGroups = "CanManageCoSerGroups";

        public static AuthorizationPolicy CanManageCoSerGroupsPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("country", "US")
                .Build();
        }
    }
}

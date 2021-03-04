using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace QTSC_ORM.Data.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}

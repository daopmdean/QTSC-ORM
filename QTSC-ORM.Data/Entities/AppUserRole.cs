using System;
using Microsoft.AspNetCore.Identity;

namespace QTSC_ORM.Data.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser AppUser { get; set; }
        public AppRole AppRole { get; set; }
    }
}

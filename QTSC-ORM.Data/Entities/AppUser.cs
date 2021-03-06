﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace QTSC_ORM.Data.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}

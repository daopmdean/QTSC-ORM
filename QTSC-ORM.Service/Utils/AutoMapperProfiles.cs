using System;
using AutoMapper;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;

namespace QTSC_ORM.Service.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterInfo, AppUser>();
            CreateMap<UserUpdate, AppUser>();
            CreateMap<AppUser, UserInfo>();
            CreateMap<Customer, CustomerReturn>();
        }
    }
}

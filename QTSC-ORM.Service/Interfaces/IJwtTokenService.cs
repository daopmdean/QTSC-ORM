using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;

namespace QTSC_ORM.Service.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}

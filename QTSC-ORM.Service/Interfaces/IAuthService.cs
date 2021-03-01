using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Models;

namespace QTSC_ORM.Service.Interfaces
{
    public interface IAuthService
    {
        Task<UserReturn> Login(LoginInfo loginInfo);
        Task<UserReturn> Register(RegisterInfo registerInfo);
    }
}

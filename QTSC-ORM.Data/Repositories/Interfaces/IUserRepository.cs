using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;

namespace QTSC_ORM.Data.Repositories
{
    public interface IUserRepository
    {
        void UpdateUser(AppUser appUser);
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<bool> SaveAllAsync();
    }
}

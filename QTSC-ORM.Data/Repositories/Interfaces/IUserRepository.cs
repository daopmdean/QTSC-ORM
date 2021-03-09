using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Data.Pagings;

namespace QTSC_ORM.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void UpdateUser(AppUser appUser);
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<PagedList<UserInfo>> GetUsersByFullNameAsync(string fullName,
            PaginationParams pagingParams);
        Task<bool> SaveAllAsync();
    }
}

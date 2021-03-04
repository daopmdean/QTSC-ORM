using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Pagings;
using QTSC_ORM.Data.Repositories.Interfaces;

namespace QTSC_ORM.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .SingleOrDefaultAsync(user => user.UserName == username.ToLower());
        }

        public async Task<PagedList<AppUser>> GetUsersByFullNameAsync(string fullName,
            PaginationParams pagingParams)
        {
            var users = _context.Users
                .OrderBy(u => u.FullName)
                .Where(user => user.FullName.Contains(fullName));

            return await PagedList<AppUser>
                .CreateAsync(users, pagingParams.PageNumber, pagingParams.PageSize);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateUser(AppUser appUser)
        {
            _context.Entry(appUser).State = EntityState.Modified;
        }
    }
}

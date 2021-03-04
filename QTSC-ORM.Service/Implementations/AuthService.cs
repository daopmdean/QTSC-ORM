using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Service.Interfaces;

namespace QTSC_ORM.Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtTokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IJwtTokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<UserReturn> Login(LoginInfo loginInfo)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(user => user.UserName == loginInfo.UserName.ToLower());

            if (user == null)
                throw new Exception("Invalid UserName");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginInfo.Password, false);

            if (!result.Succeeded)
                throw new Exception("Invalid Password");

            return new UserReturn
            {
                Id = user.Id,
                AccessToken = await _tokenService.CreateTokenAsync(user)
            };
        }

        public async Task<UserReturn> Register(RegisterInfo registerInfo)
        {
            if (await UserExists(registerInfo.UserName))
                throw new Exception("Username already exist");

            var user = _mapper.Map<AppUser>(registerInfo);
            user.UserName = registerInfo.UserName.ToLower();

            var result = await _userManager.CreateAsync(user, registerInfo.Password);

            if (!result.Succeeded)
                throw new Exception(result.Errors.ToString());

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if (!roleResult.Succeeded)
                throw new Exception(result.Errors.ToString());

            return new UserReturn
            {
                Id = user.Id,
                AccessToken = await _tokenService.CreateTokenAsync(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(
                user => user.UserName == username.ToLower());
        }
    }
}

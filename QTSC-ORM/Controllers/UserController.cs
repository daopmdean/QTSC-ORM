using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Data.Repositories.Interfaces;
using QTSC_ORM.Extensions;

namespace QTSC_ORM.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(UserUpdate userUpdate)
        {
            var username = User.GetUserName();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            _mapper.Map(userUpdate, user);
            _userRepository.UpdateUser(user);

            if (await _userRepository.SaveAllAsync())
                return NoContent();

            return BadRequest("Fail to update user");
        }

    }
}

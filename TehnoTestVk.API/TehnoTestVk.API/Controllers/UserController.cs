using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TehnoTest.BLL.Interfaces;
using TehnoTest.BLL.Models;
using TehnoTestVk.API.Models.UserModels.Request;
using TehnoTestVk.API.Models.UserModels.Response;

namespace TechnoTest.API.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserManager _userManager;

        public UserController(IMapper mapper, IUserManager userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet(Name = "GetAllUsersAsync")]
        public async Task<IActionResult> GetAllActiveUsersAsync()
        {
            try
            {
                var listUsers = await _userManager.GetAllUsersAsync();
                var result = _mapper.Map<IEnumerable<UserResponse>>(listUsers);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int userId)
        {
            try
            {
                var user = await _userManager.GetUserByIdAsync(userId);
                var result = _mapper.Map<UserResponse>(user);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserRequest userAdd)
        {
            try
            {
                var user = _mapper.Map<UserModelBLL>(userAdd);
                var userBll = await _userManager.CreateUserAsync(user);
                var result = _mapper.Map<UserResponse>(userBll);


                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{userId}" , Name = "DeleteUser")]
        public async Task<ActionResult> DeleteUserAsync([FromRoute] int userId)
        {
            try
            {
                _userManager.DeleteUserAsync(userId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

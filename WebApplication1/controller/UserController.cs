using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.mapper;
using WebApplication1.model;

namespace WebApplication1.controller;

 [ApiController]
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserEntityResponse>> CreateUser([FromBody] AddUserRequest request)
        {
            User userCreated = await _userService.CreateUserAsync(request.Name,
                request.Email,
                request.Password,
                request.Telephone);
            
            return CreatedAtAction(nameof(CreateUser), UserMapper.ToDTO(userCreated));
        }

        [HttpGet]
        public async Task<ActionResult<UserEntityResponse>> GetAllUsers(int pageNumber = 1, int pageSize = 10)
        {
            List<User?> userList = await _userService.GetUsersAsync(pageNumber, pageSize);

            return Ok(UserMapper.ToDTO(userList));
        }

        [HttpPatch("{userId}")]
        public async Task<ActionResult<UserEntityResponse>> UpdateUserEmail(int userId, [FromBody] UpdateUserEmailRequest request)
        {
            User userUpdated = await _userService.UpdateUserEmail(userId, request.newEmail);
            return Ok(userUpdated);
        }
        
        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(int  userId)
        {
           await _userService.DeleteUserAsync(userId);
            return NoContent();
        }
    }

    public record AddUserRequest(string Name, string Email, string Password, string Telephone);
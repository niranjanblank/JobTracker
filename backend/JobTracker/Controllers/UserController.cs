using Microsoft.AspNetCore.Mvc;
using JobTracker.Models;
using JobTracker.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Get a user by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            var newUser = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        /// <summary>
        /// Delete a user by ID
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}

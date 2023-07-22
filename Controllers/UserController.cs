using EliteBackend.Models;
using EliteBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace EliteBackend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly MongoDBService _db;

        public UserController(MongoDBService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<User>> GetUsers() => await _db.GetAllsers();

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            if (!IsUserIDValid(id))
            {
                return BadRequest("Invalid user ID");
            }
            var user = await _db.GetUserByUsername(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }


        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromBody] User user)
        {
            if (!IsUserIDValid(user.Id))
            {
                return BadRequest("Invalid user ID");
            } 
            if (!IsSexValueValid(user.Sex))
            {
                return BadRequest("Invalid sex type: Should be MALE or FEMALE");
            }
            await _db.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpadateUser(string id, [FromBody] User updatedUser)
        {
            if (!IsUserIDValid(id))
            {
                return BadRequest("Invalid user ID");
            }
            if ((updatedUser.Sex != null) && IsSexValueValid(updatedUser.Sex))
            {
                return BadRequest("Invalid sex type: Should be MALE or FEMALE");
            }

            var userExist = await _db.GetUser(id);

            if (userExist is null)
            {
                return NotFound();
            }

            updatedUser.Id = userExist.Id;

            await _db.Updateuser(id, updatedUser);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {

            if (!IsUserIDValid(id))
            { 
                return BadRequest("Invalid user ID");
            }

            var user = await _db.GetUser(id);

            if (user is null)
            {
                return NotFound();
            }

            await _db.RemoveUser(id);

            return NoContent();
        }

        private bool IsUserIDValid(String id)
        {
            try
            {
                Guid guid = new Guid(id);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool IsSexValueValid(String sex)
        {
            return sex.Equals("MALE") || sex.Equals("FEMALE");
        }
    }
}

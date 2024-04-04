using Discord_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscordUsersController : ControllerBase
    {
        private IDiscordUsersRepository _usersRepository;

        public DiscordUsersController(IDiscordUsersRepository temp)
        {
            _usersRepository = temp;
        }

        // GET /api/DiscordUsers/
        [HttpGet]
        public IEnumerable<DiscordUsers> Get()
        {
            var DiscordUsersData = _usersRepository.GetUsers.ToArray();

            return DiscordUsersData;
        }


        // Adding Discord Users to our discord userdatabase
        [HttpPost]
        public async Task<ActionResult<DiscordUsers>> Post(DiscordUsers discordUser)
        {
            if (discordUser == null)
            {
                return BadRequest();
            }

            try
            {
                var newDiscordUser = await _usersRepository.CreateDiscordUsersAsync(discordUser);
                return CreatedAtAction(nameof(Get), new { id = newDiscordUser.Id }, newDiscordUser);
            }
            catch (Exception ex)
            {
                // Logs Exception
                return StatusCode(500, "Internal Server error");
            }
        }

        // Updating Discord user status to Blocked/Admin
        [HttpPut]
        public async Task<ActionResult<DiscordUsers>> Put(DiscordUsers discordUser)
        {
            var userId = _usersRepository.GetUserById(discordUser.Id);

            if (userId == null)
            {
                return BadRequest();
            }
            try
            {
                await _usersRepository.UpdateDiscordUsersAsync(discordUser, true, discordUser.isAdmin);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, "internal server error");
            }
        }
    }
}

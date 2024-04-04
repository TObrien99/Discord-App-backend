using Discord_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Collections;
using System.Threading.Tasks;


namespace Discord_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscordBotRequestsController : ControllerBase
    {
        private IDiscordBotRequestsRepository _requestRepository;

        public DiscordBotRequestsController(IDiscordBotRequestsRepository temp)
        {
            // connected the database to this repository via this instantiation
            _requestRepository = temp;
        }

        // GET /api/DiscordBotRequests/
        [HttpGet]
        public IEnumerable<DiscordBotRequests> Get()
        {
            var BotRequestData = _requestRepository.BotRequests.ToArray();

            return BotRequestData;
        }


        // POST /api/DiscordBotRequests/
        [HttpPost]
        public async Task<ActionResult<DiscordBotRequests>> Post(DiscordBotRequests botRequest)
        {
            if (botRequest == null)
            {
                return BadRequest();
            }

            try
            {
                var newBotRequest = await _requestRepository.CreateBotRequestAsync(botRequest);
                return CreatedAtAction(nameof(Get), new { id = newBotRequest.Id }, newBotRequest);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

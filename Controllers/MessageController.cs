using MessengerApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessengerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly MessengerDbContext _context;

        public MessageController(MessengerDbContext context)
        {
            _context = context;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return Ok(message);
        }
        [HttpGet("{chatId}")]
        public IActionResult GetMessage(int chatId)
        {
            var messages = _context.Messages
                .Where(m => m.ChatId == chatId)
                .ToList();

            return Ok(messages);
        }
    }
}

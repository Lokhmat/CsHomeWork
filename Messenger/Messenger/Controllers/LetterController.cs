using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Controllers
{
    /// <summary>
    /// Messages related controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LetterController : ControllerBase
    {
        /// <summary>
        /// Find message by sender email and receiver email.
        /// </summary>
        /// <returns> Found letter.</returns>
        [HttpGet("letter")]
        public ActionResult<IEnumerable<Letter>> GetLetterByBoth(string sender, string receiver)
        {
            var ans = Chat.GetInstance().Letters.Where(x => x.SenderId == sender && x.RecieverId == receiver).ToList();
            if (ans.Count > 0)
                return ans;
            return NotFound();
        }
        /// <summary>
        /// Find letter by sender email.
        /// </summary>
        /// <returns> Found letter.</returns>
        [HttpGet("sender")]
        public ActionResult<IEnumerable<Letter>> GetLetterBySender(string sender)
        {
            var ans = Chat.GetInstance().Letters.Where(x => x.SenderId == sender).ToList();
            if (ans.Count > 0)
                return ans;
            return NotFound();
        }
        /// <summary>
        /// Find letter by receiver email.
        /// </summary>
        /// <returns> Found letter.</returns>
        [HttpGet("receiver")]
        public ActionResult<IEnumerable<Letter>> GetLetterByReceiver(string receiver)
        {
            var ans = Chat.GetInstance().Letters.Where(x => x.RecieverId == receiver).ToList();
            if (ans.Count > 0)
                return ans;
            return NotFound();
        }
        /// <summary>
        /// Adds message.
        /// </summary>
        /// <returns> Status code.</returns>
        [HttpPost("add")]
        public ActionResult AddMessage(string sender, string receiver, string message, string subject)
        {
            if (Chat.GetInstance().Users.Select(x => x.Email).Contains(sender) && Chat.GetInstance().Users.Select(x => x.Email).Contains(receiver))
            {
                Chat.GetInstance().Letters.Add(new Letter(subject, message, sender, receiver));
                Chat.GetInstance().SerializeChat();
                return Ok();
            }
            return NotFound();
        }
    }
}

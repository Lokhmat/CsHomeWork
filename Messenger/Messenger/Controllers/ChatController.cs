using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Controllers
{
    /// <summary>
    /// Controller for chat.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        /// <summary>
        /// Reads chat from special file.
        /// </summary>
        /// <returns> Status code.</returns>
        [HttpGet("deserialize")]
        public ActionResult Deserialize()
        {
            try
            {
                Chat.GetInstance().DeserializeChat();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// API for generating random chat.
        /// </summary>
        /// <returns> Status code.</returns>
        [HttpPost("generate")]
        public ActionResult Generate()
        {
            try
            {
                Chat.GetInstance().GenerateRandom();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

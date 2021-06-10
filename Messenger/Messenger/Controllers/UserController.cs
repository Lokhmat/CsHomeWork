using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Messenger.Controllers
{
    /// <summary>
    /// Users related controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        /// <summary>
        /// Find user by email.
        /// </summary>
        /// <param name="email"> Email to find with.</param>
        /// <returns> Found user.</returns>
        [HttpGet("email")]
        public ActionResult<IEnumerable<User>> GetUsersByEmail(string email)
        {
            var ans = Chat.GetInstance().Users.Where(x => x.Email == email).ToList();
            if (ans.Count > 0)
                return ans;
            return NotFound();
        }
        /// <summary>
        /// Returns list of all users.
        /// </summary>
        /// <returns>List of all users.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers(int offset, int limit)
        {
            var ans = Chat.GetInstance().Users.Skip(offset).Take(limit).ToList();
            if (offset < 0 || limit <= 0)
                return BadRequest();
            if (ans.Count > 0)
                return ans;
            return NotFound();
        }
        /// <summary>
        /// Creates user by prespecified parameters.
        /// </summary>
        /// <param name="username"> Username of new user.</param>
        /// <param name="email"> Email of new user.</param>
        /// <returns> Status code.</returns>
        [HttpPost("create")]
        public ActionResult Create(string username, string email)
        {
            try
            {
                Chat.GetInstance().Users.Add(new User(username, email));
                Chat.GetInstance().SerializeChat();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}

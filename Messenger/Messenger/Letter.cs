using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger
{
    /// <summary>
    /// Class for message implementation.
    /// </summary>
    public class Letter
    {
        public string Subject { get; private set; }
        public string Message { get; private set; }
        public string SenderId { get; private set; }
        public string RecieverId { get; private set; }
        public Letter(string subject, string message, string senderId, string recieverId)
        {
            Subject = subject;
            Message = message;
            SenderId = senderId;
            RecieverId = recieverId;
        }

    }
}

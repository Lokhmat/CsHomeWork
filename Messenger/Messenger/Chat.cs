using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Messenger
{
    /// <summary>
    /// Class for Chat realization. Implements Sigleton.
    /// </summary>
    public class Chat
    {
        public List<User> Users { get; private set; }
        public List<Letter> Letters { get; private set; }
        static Chat chat;
        /// <summary>
        /// Private constructor for initialization.
        /// </summary>
        private Chat()
        {
            Users = new List<User>();
            Letters = new List<Letter>();
        }
        /// <summary>
        /// Costructor for serialization.
        /// </summary>
        /// <param name="users"> List of Users.</param>
        /// <param name="letters"> List of messages.</param>
        private Chat(List<User> users, List<Letter> letters)
        {
            this.Users = users;
            this.Letters = letters;

        }
        /// <summary>
        /// Returns current instance of a chat.
        /// </summary>
        public static Chat GetInstance()
        {
            if (chat is null)
            {
                chat = new Chat();
                return chat;
            }
            return chat;
        }
        /// <summary>
        /// Serializes chat into json.
        /// </summary>
        public void SerializeChat()
        {
            JsonSerializer serializer = new JsonSerializer();
            chat.Users = chat.Users.OrderBy(x => x.Email).ToList();
            var chatFile = JsonConvert.SerializeObject(chat);
            try
            {
                using (StreamWriter sw = new StreamWriter("chat.json"))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {

                        serializer.Serialize(writer, chat);
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Deserializes chat from special file.
        /// </summary>
        public void DeserializeChat()
        {
            using (StreamReader sr = new StreamReader("chat.json"))
            {
                chat = JsonConvert.DeserializeObject<Chat>(sr.ReadToEnd());
            }
        }
        /// <summary>
        /// Fill chat with random letters and users.
        /// </summary>
        public void GenerateRandom()
        {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random rnd = new Random();
            int users = rnd.Next(1, 10);
            int letters = rnd.Next(1, 20);
            for (int i = 0; i < users; i++)
            {
                string email = GenerateRandomString(chars, rnd);
                string name = GenerateRandomString(chars, rnd);
                chat.Users.Add(new User(name.ToString(), email.ToString()));
            }
            for (int i = 0; i < letters; i++)
            {

                chat.Letters.Add(new Letter(GenerateRandomString(chars, rnd), GenerateRandomString(chars, rnd), chat.Users[rnd.Next(0, chat.Users.Count)].Email, chat.Users[rnd.Next(0, chat.Users.Count)].Email));
            }
            SerializeChat();
        }
        /// <summary>
        /// Generates random string from list of chars.
        /// </summary>
        /// <param name="chars"> Chars to pick from.</param>
        /// <param name="rnd"> Random instance.</param>
        /// <returns> Random string of random length(from 1 to 15).</returns>
        private static string GenerateRandomString(string chars, Random rnd)
        {
            int size = rnd.Next(1, 15);
            StringBuilder email = new StringBuilder();
            for (int j = 0; j < size; j++)
            {
                email.Append(chars[rnd.Next(0, 55)]);
            }

            return email.ToString();
        }
    }
}

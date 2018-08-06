using System;
using System.Collections.Generic;
using System.Text;

namespace BUKMACHER_CORE.Domain
{
    public class Player
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Voucher Voucher { get; protected set; }
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Player()
        {}
        public Player(string username, string email, string password, string salt)
        {
            UserId = Guid.NewGuid();
            Username = username;
            Email = email;
            Password = password;
            Salt = salt;

        }
    }
}

using System;

namespace SportsBetting.Core.Domain
{
    public class Bookmaker
    {
        public string BookmakerName { get; protected set; }
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Bookmaker()
        {}

        protected Bookmaker(string bookmaker)
        {
            Id = Guid.NewGuid();
            BookmakerName = bookmaker;
            CreatedAt = DateTime.UtcNow;
        }

        protected void SetBookmakerName(string BName)
        {
            if (string.IsNullOrWhiteSpace(BName))
                throw new Exception("Your BookmakerName is invalid!");
            BookmakerName = BName;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Bookmaker Create(string name)
            => new Bookmaker(name);
    }
}
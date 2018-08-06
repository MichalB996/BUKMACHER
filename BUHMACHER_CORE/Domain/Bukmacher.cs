using System;

namespace BUKMACHER_CORE.Domain
{
    public class Bukmacher
    {
        public string BukmacherName { get; protected set; }
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Bukmacher()
        {}
        public Bukmacher(string bukmachername)
        {
            Id = Guid.NewGuid();
            BukmacherName = bukmachername;
            CreatedAt = DateTime.UtcNow;
        }

    }
}
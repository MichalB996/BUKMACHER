using System;

namespace BUKMACHER_CORE.Domain
{
    public class Bukmacher
    {
        public string BukmacherName { get; protected set; }
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Bukmacher()
        {}
        protected Bukmacher(string bukmachername)
        {
            Id = Guid.NewGuid();
            BukmacherName = bukmachername;
            CreatedAt = DateTime.UtcNow;
        }
        protected void SetBukmacherName(string BName)
        {
            if (string.IsNullOrWhiteSpace(BName))
                throw new Exception("Your BukmacherName is invalid!");
            BukmacherName = BName;
            UpdatedAt = DateTime.UtcNow;
        }
        public static Bukmacher Create(string name)
            => new Bukmacher(name);
    }
}
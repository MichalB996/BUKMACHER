using System;

namespace SportsBetting.Infrastructure.DTO
{
    public class BookmakerDTO
    {
        public string BukmacherName { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

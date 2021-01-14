using System;

namespace HomeCash.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public Guid HomeBaseId { get; set; }

        public virtual HomeBase HomeBase { get; set; }
    }
}
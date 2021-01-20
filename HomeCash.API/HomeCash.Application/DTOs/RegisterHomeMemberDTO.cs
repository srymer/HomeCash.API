using System;

namespace HomeCash.Application.DTOs
{
    public class RegisterHomeMemberDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid HomeBaseId { get; set; }
        public string Role { get; set; }
    }
}
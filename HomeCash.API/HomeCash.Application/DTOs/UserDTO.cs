﻿using System;

namespace HomeCash.Application.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string HomeName { get; set; }
        public Guid HomeBaseId { get; set; }
    }
}
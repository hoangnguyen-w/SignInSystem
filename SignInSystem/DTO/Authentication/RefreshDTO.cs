﻿#nullable disable
using SignInSystem;

namespace SignInSystem.DTO.Authentication
{
    public class RefreshDTO
    {
        public string Token { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Expires { get; set; }
    }
}

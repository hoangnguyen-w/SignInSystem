#nullable disable
using SignInSystem;

namespace SignInSystem.DTO.Authentication
{
    public class TokenDTO
    {
        public string id { get; set; }

        public string name { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public string Role { get; set; }
    }
}

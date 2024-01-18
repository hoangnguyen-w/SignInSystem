#nullable disable
using SignInSystem.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SignInSystem.Entity
{
    public class Account
    {
        [Key]
        public int AccountID { get;set; }
        
        public string AccountName { get; set; }

        [Required]
        public string Email { get;set; }

        [Required]
        public string Password { get;set; }


        //KHóa ngoại
        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }

        //JWT authentication
        public string RefreshToken { get; set; }
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }
    }
}

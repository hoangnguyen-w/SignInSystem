using System.ComponentModel.DataAnnotations;
#nullable disable
namespace SignInSystem.Entity
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}

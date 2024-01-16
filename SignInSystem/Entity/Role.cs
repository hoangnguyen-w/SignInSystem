using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
#nullable disable
namespace SignInSystem.Entity
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        public string RoleName { get; set; }
        
        
        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }

        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }

        [JsonIgnore]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}

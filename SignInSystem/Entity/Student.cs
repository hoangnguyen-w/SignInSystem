﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace SignInSystem.Entity
{
    public class Student
    {
        [Key]
        public string StudentID { get; set; }

        public string StudentName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string ParentName { get; set; }

        public string Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(20)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Input your Number")]
        public string Phone { get; set; }

        public string Image { get; set; }

        public string Gender { get; set; }

        public bool NewStudent { get; set; }


        //Khóa ngoại
        [ForeignKey("Voucher")]
        public int? VoucherID { get; set; }
        public virtual Voucher Voucher { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }


        [JsonIgnore]
        public virtual ICollection<Score> Scores { get; set; }

        //[JsonIgnore]
        public virtual ICollection<Tuition> Tuitions { get; set; }


        //JWT authentication
        public string RefreshToken { get; set; }
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }
    }
}

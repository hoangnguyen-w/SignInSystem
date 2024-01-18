﻿#nullable disable
using SignInSystem;
using System.ComponentModel.DataAnnotations;

namespace SignInSystem.DTO.Student
{
    public class RegisterStudentDTO
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        [MaxLength(20)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Input your Number")]
        public string Phone { get; set; }

        public string Address { get; set; }

        public string ParentName { get; set; }  

        public string Password { get; set; }

    }
}
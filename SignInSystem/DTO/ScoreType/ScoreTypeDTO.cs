﻿#nullable disable
using System.ComponentModel.DataAnnotations;

namespace SignInSystem.DTO.ScoreType
{
    public class ScoreTypeDTO
    {
        public string ScoreTypeName { get; set; }
        
        [Required]
        [Range(0, 10, ErrorMessage = "Lỗi nhập hệ số, hệ số là số nguyên và từ 1 đến 10")]
        public int Coefficient { get; set; }
    }
}

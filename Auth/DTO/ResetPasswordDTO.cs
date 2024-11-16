using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Jawlaty.Auth.DTO
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Email { get; set; }=string.Empty;

        [Required]
        public string NewPassword { get; set; } = string.Empty;

        public string? Token { get; set; } = string.Empty;
    }
}

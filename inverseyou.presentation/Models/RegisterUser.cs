using inverseyou.ddd.Values;
using System;
using System.ComponentModel.DataAnnotations;

namespace inverseyou.presentation.Models
{
    public class RegisterUser
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        [StringLength(20,MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        public Gender GenderCode { get; set; }
        [Required]
        public UserAccountStatus AccountStatusCode { get; set; }
    }
}

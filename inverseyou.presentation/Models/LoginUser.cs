using System.ComponentModel.DataAnnotations;

namespace inverseyou.presentation.Models
{
    public class LoginUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}

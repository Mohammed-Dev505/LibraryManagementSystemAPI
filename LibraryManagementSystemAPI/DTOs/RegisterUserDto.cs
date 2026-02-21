using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.DTOs
{
    public class RegisterUserDto
    {
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,MinLength(6)]
        public string PhoneNumber { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.DTOs
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}

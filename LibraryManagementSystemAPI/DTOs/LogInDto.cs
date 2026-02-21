using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.DTOs
{
    public class LogInDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.DTOs
{
    public class AssignRoleDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}

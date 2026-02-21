using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.DTOs
{
    public class CreateRoleDto
    {
        [Required]
        public string RoleName { get; set; }
    }
}

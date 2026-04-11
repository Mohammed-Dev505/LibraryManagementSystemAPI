using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Data.Models
{
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Role {  get; set; }
    }
}

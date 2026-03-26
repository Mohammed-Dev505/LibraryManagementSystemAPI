using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Data
{
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Role {  get; set; }
    }
}

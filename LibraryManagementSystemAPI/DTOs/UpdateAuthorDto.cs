using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.DTOs
{
    public class UpdateAuthorDto
    {
        [Required]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string? Biography { get; set; }
    }
}

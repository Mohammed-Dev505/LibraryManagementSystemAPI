using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.DTOs
{
    public class UpdateBookDto
    {
        [Required]
        public int Id { get; set; }
        [Required,MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int CopiesAvailable { get; set; }
    }
}

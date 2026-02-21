using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.DTOs
{
    public class CreateBookDto
    {
        [MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public int CopiesAvailable { get; set; }
    }
}

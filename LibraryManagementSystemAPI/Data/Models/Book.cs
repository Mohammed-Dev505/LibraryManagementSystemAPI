using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trining_RESTApi.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public int CopiesAvailable { get; set; }
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}

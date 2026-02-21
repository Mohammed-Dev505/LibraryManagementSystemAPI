using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trining_RESTApi.Data.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public int Rating { get; set; } // 1 - 5
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}

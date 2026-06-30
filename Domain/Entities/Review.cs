using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystemAPI.Domain.Entities
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }
        public int Rating { get; set; } // 1 - 5
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}

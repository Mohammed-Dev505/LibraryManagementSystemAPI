using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Domain.Entities
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
        [Required,StringLength(100)]
        public string Name { get; set; }
        public string Biography { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

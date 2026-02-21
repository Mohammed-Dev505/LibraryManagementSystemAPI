using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Name { get; set; }
        public string Biography { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

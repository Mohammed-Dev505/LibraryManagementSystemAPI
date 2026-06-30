using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryManagementSystemAPI.Domain.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public class Borrow
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BorrowStatus Status { get; set; } = BorrowStatus.Borrowed;
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}

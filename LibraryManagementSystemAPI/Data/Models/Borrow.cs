using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Trining_RESTApi.Data.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BorrowStatus { Borrowed , Returned , Overdue}
    public class Borrow
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BorrowStatus Status { get; set; } = BorrowStatus.Borrowed;

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}

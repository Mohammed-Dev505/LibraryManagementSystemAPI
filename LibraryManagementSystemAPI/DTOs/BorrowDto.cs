using Trining_RESTApi.Data.Models;

namespace Trining_RESTApi.DTOs
{
    public class BorrowDto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string UserName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BorrowStatus Status { get; set; }

    }
}

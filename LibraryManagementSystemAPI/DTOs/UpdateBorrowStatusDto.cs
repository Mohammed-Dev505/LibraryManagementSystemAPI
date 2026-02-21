using Trining_RESTApi.Data.Models;

namespace Trining_RESTApi.DTOs
{
    public class UpdateBorrowStatusDto
    {
        public int Id { get; set; }
        public BorrowStatus Status { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}

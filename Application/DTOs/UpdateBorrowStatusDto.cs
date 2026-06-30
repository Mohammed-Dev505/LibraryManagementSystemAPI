

using Domain;

namespace LibraryManagementSystemAPI.Application.DTOs
{
    public class UpdateBorrowStatusDto
    {
        public BorrowStatus Status { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}

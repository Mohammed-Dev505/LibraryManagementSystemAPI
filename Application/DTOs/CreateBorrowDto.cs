namespace LibraryManagementSystemAPI.Application.DTOs
{
    public class CreateBorrowDto
    {
        public Guid BookId { get; set; }
        public DateTime DueDate { get; set; }
    }
}

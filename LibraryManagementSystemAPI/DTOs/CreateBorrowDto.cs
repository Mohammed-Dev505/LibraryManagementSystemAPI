namespace Trining_RESTApi.DTOs
{
    public class CreateBorrowDto
    {
        public int BookId { get; set; }
        public DateTime DueDate { get; set; }
    }
}

namespace Trining_RESTApi.DTOs
{
    public class CreateBorrowDto
    {
        public int BookId { get; set; }
        public string UserId { get; set; }
        public DateTime DueDate { get; set; }
    }
}

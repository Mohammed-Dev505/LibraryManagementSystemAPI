namespace Trining_RESTApi.DTOs
{
    public class ReviewDto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

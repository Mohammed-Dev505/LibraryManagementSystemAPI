namespace Trining_RESTApi.DTOs
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public DateTime publishedDate { get; set; }
        public int CopiesAvailable { get; set; }
        public string AuthorName { get; set; }
    }
}

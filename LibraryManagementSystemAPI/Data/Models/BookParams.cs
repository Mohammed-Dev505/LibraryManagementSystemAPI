namespace LibraryManagementSystemAPI.Data.Models
{
    public class BookParams : PaginationParams
    {
        public string? AuthorName { get; set; }
        public string? Title { get; set; }
    }
}

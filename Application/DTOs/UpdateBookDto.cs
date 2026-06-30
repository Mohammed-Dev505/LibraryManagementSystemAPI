

namespace LibraryManagementSystemAPI.Application.DTOs
{
    public class UpdateBookDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? CopiesAvailable { get; set; }
    }
}

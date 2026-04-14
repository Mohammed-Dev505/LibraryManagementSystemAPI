using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.DTOs
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CopiesAvailable { get; set; }
    }
}

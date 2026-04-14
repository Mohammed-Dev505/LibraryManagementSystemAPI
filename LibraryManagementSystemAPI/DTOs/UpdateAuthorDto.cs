using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.DTOs
{
    public class UpdateAuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Biography { get; set; }
    }
}

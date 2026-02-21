using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.DTOs
{
    public class CreateAuthorDto
    {
        [Required,MaxLength(100)]
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}

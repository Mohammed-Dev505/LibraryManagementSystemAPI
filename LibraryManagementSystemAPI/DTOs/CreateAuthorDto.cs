using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Trining_RESTApi.DTOs
{
    public class CreateAuthorDto
    {
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}

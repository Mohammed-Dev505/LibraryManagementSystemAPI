using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trining_RESTApi.Data.Models;
using Trining_RESTApi.DTOs;
using Trining_RESTApi.Services.Interfaces;

namespace Trining_RESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService) => _authorService = authorService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null) return NotFound("Author not found");
            return Ok(author);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorDto dto)
        {
            var author = await _authorService.CreateAuthorAsync(dto);
            if (author == null) return BadRequest("Unable to create author");
            return Created(string.Empty, author);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id , UpdateAuthorDto dto)
        {
            if (id != dto.Id) return BadRequest("Id is match");
            var updated = await _authorService.UpdateAuthorAsync(dto);
            if (!updated) return NotFound("Author not found");
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var deleted = await _authorService.DeleteAuthorAsync(id);
            if (!deleted) return NotFound("Author not found");
            return NoContent();
        }
    }
}

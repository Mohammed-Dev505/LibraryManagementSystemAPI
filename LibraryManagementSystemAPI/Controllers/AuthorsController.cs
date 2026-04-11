using LibraryManagementSystemAPI.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trining_RESTApi.Data.Models;
using Trining_RESTApi.DTOs;
using Trining_RESTApi.Services.Interfaces;

namespace Trining_RESTApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService) => _authorService = authorService;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] AuthorParams pagination)
        {
            var authors = await _authorService.GetAllAsync(pagination);
            return Ok(authors);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            return Ok(author);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorDto dto)
        {
            var author = await _authorService.CreateAuthorAsync(dto);
            return Created(string.Empty, author);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id , UpdateAuthorDto dto)
        {
            if (id != dto.Id) return BadRequest("Id mismatch");
            var updated = await _authorService.UpdateAuthorAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var deleted = await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}

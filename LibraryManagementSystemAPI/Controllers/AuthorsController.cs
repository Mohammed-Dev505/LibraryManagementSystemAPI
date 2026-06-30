
using LibraryManagementSystemAPI.Application.DTOs;
using LibraryManagementSystemAPI.Application.Models;
using LibraryManagementSystemAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
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
        public async Task<IActionResult> GetById(Guid id)
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
        public async Task<IActionResult> Update(Guid id , UpdateAuthorDto dto)
        {
            var updated = await _authorService.UpdateAuthorAsync( id, dto);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var deleted = await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}

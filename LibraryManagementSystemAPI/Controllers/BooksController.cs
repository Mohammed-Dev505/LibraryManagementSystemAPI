
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
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService) => _bookService = bookService;

        [HttpGet("books")]
        public async Task<IActionResult> GetAll([FromQuery]BookParams pagination) => Ok(await _bookService.GetAllAsync(pagination)); 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _bookService.GetByIdAsync(id);
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto dto)
        {
            var result = await _bookService.CreateAsync(dto);
            return Created(string.Empty, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id , UpdateBookDto dto)
        {
            var success = await _bookService.UpdateAsync( id, dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
           var success = await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}

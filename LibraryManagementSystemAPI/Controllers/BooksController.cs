using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using Trining_RESTApi.DTOs;
using Trining_RESTApi.Services.Interfaces;

namespace Trining_RESTApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService) => _bookService = bookService;

        [HttpGet("books")]
        public async Task<IActionResult> GetAll() => Ok(await _bookService.GetAllAsync()); 

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
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
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id , UpdateBookDto dto)
        {
            if (id != dto.Id) return BadRequest("Id mismatch");
            var success = await _bookService.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
           var success = await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}

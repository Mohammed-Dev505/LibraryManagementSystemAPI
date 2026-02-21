using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trining_RESTApi.Data.Models;
using Trining_RESTApi.DTOs;
using Trining_RESTApi.Services.Interfaces;

namespace Trining_RESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService) => _reviewService = reviewService;

        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetByBook(int bookId) => Ok(await _reviewService.GetByBookAsync(bookId));

        [HttpPost]
        public async Task<IActionResult> Create(CreateReviwDto dto) => Created(string.Empty, await _reviewService.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , UpdateReviewDto dto)
        {
            if(id != dto.Id) return BadRequest();
            var success = await _reviewService.UpdateAsync(dto);
            return success ? NoContent() : NotFound();
        }
    }
}

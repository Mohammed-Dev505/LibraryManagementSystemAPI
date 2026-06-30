
using LibraryManagementSystemAPI.Application.DTOs;
using LibraryManagementSystemAPI.Application.Models;
using LibraryManagementSystemAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryManagementSystemAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService) => _reviewService = reviewService;

        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetByBook(Guid bookId , [FromQuery] PaginationParams parameters) => Ok(await _reviewService.GetByBookAsync(bookId , parameters));

        [HttpPost]
        public async Task<IActionResult> Create(CreateReviwDto dto)
        {
            var userId = User.FindFirstValue("uid");
            return Created(string.Empty, await _reviewService.CreateAsync(dto, userId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id , UpdateReviewDto dto)
        {
            var userId = User.FindFirstValue("uid");
            var success = await _reviewService.UpdateAsync(id, dto, userId);
            return NoContent();
        }
    }
}

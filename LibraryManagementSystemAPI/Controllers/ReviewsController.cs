using LibraryManagementSystemAPI.Data.Models;
using LibraryManagementSystemAPI.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Trining_RESTApi.Data.Models;
using Trining_RESTApi.DTOs;
using Trining_RESTApi.Services.Interfaces;

namespace Trining_RESTApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService) => _reviewService = reviewService;

        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetByBook(int bookId , [FromQuery] PaginationParams parameters) => Ok(await _reviewService.GetByBookAsync(bookId , parameters));

        [HttpPost]
        public async Task<IActionResult> Create(CreateReviwDto dto)
        {
            var userId = User.FindFirstValue("uid");
            return Created(string.Empty, await _reviewService.CreateAsync(dto, userId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , UpdateReviewDto dto)
        {
            if (id != dto.Id) throw new BadRequestException("id mismatch");
            var success = await _reviewService.UpdateAsync(dto);
            return NoContent();
        }
    }
}

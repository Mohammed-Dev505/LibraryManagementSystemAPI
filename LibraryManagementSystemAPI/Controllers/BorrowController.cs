
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
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _borrowService;
        public BorrowController(IBorrowService borrowService) => _borrowService = borrowService;

        [HttpGet("")]
        public async Task<IActionResult> GetByUser([FromQuery] PaginationParams pagination)
        {
            var userId = User.FindFirstValue("uid");
            return Ok(await _borrowService.GetBorrowsByUserAsync(userId , pagination));
        }

        [HttpPost]
        public async Task<IActionResult> Borrow(CreateBorrowDto dto)
        {
            var userId = User.FindFirstValue("uid");
            var result = await _borrowService.CreateAsync(dto , userId);
            return Created(string.Empty, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(Guid id , UpdateBorrowStatusDto dto)
        {
            var success = await _borrowService.UpdateStatusAsync( id, dto);
            return NoContent();
        }
    }
}

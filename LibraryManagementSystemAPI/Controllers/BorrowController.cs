using LibraryManagementSystemAPI.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Claims;
using Trining_RESTApi.Data.Models;
using Trining_RESTApi.DTOs;
using Trining_RESTApi.Services.Interfaces;

namespace Trining_RESTApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _borrowService;
        public BorrowController(IBorrowService borrowService) => _borrowService = borrowService;

        [HttpGet("")]
        public async Task<IActionResult> GetByUser()
        {
            var userId = User.FindFirstValue("uid");
            return Ok(await _borrowService.GetBorrowsByUserAsync(userId));
        }

        [HttpPost]
        public async Task<IActionResult> Borrow(CreateBorrowDto dto)
        {
            var userId = User.FindFirstValue("uid");
            var result = await _borrowService.CreateAsync(dto , userId);
            return Created(string.Empty, result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStatus(int id , UpdateBorrowStatusDto dto)
        {
            if (id != dto.Id) throw new BadRequestException("id mismatch");
            var success = await _borrowService.UpdateStatusAsync(dto);
            return NoContent();
        }
    }
}

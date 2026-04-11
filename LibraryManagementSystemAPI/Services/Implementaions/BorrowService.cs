using AutoMapper;
using LibraryManagementSystemAPI.Data.Models;
using LibraryManagementSystemAPI.Exceptions;
using LibraryManagementSystemAPI.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Trining_RESTApi.Data;
using Trining_RESTApi.Data.Models;
using Trining_RESTApi.DTOs;
using Trining_RESTApi.Services.Interfaces;

namespace Trining_RESTApi.Services.Implementaions
{
    public class BorrowService : IBorrowService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public BorrowService(AppDbContext context , UserManager<User> userManager , IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<BorrowDto?> CreateAsync(CreateBorrowDto dto , string userId)
        {
            var borrowExists = _context.Borrows.Any(a => a.UserId == userId && a.BookId == dto.BookId && a.ReturnDate == null);
            if (borrowExists)
                throw new BadRequestException($"User already has an active borrowing for this book");
            var borrow = _mapper.Map<Borrow>(dto);
            if (borrow == null) throw new BadRequestException("Falid to map borrow the provided data");
            borrow.UserId = userId;
            await _context.AddAsync(borrow);
            await _context.SaveChangesAsync();
            return _mapper.Map<BorrowDto>(borrow);   
        }

        public async Task<PagedResult<BorrowDto>> GetBorrowsByUserAsync(string userId , PaginationParams pagination)
        {
            var query = _context.Borrows.Where(a => a.UserId == userId).Include(a => a.User).Include(a => a.Book).AsNoTracking().AsQueryable();
            var pagedBorrow = await query.ToPagedResultAsync(pagination.PageNumber, pagination.PageSize);
            return new PagedResult<BorrowDto>
            {
                Data = _mapper.Map<IEnumerable<BorrowDto>>(pagedBorrow.Data),
                PageNumber = pagedBorrow.PageNumber,
                PageSize = pagedBorrow.PageSize,
                TotalCount = pagedBorrow.TotalCount,
                TotalPages = pagedBorrow.TotalPages
            };
        }

        public async Task<bool> UpdateStatusAsync(UpdateBorrowStatusDto dto)
        {
            var borrowing = await _context.Borrows.FindAsync(dto.Id);
            if(borrowing == null) throw new NotFoundException($"Borrow with ID {dto.Id} not found");
            borrowing.Status = dto.Status;
            borrowing.ReturnDate = dto.ReturnDate;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

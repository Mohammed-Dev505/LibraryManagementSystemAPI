using AutoMapper;
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
        public async Task<BorrowDto?> CreateAsync(CreateBorrowDto dto)
        {
            var borrow = _mapper.Map<Borrow>(dto);
            await _context.AddAsync(borrow);
            await _context.SaveChangesAsync();
            return _mapper.Map<BorrowDto>(borrow);   
        }

        public async Task<IEnumerable<BorrowDto>> GetBorrowsByUserAsync(string userId)
        {
            var borrowing = await _context.Borrows.Where(a => a.UserId == userId).Include(a => a.User).Include(a => a.Book).ThenInclude(a => a.Author).AsNoTracking().ToListAsync();
            return _mapper.Map<List<BorrowDto>>(borrowing);
        }

        public async Task<bool> UpdateStatusAsync(UpdateBorrowStatusDto dto)
        {
            var borrowing = await _context.Borrows.FindAsync(dto.Id);
            if(borrowing == null) return false;
            borrowing.Status = dto.Status;
            borrowing.ReturnDate = dto.ReturnDate;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

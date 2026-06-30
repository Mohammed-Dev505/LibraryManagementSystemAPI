using Application.Services.Interfaces;
using AutoMapper;
using LibraryManagementSystemAPI.Application.DTOs;
using LibraryManagementSystemAPI.Application.Exceptions;
using LibraryManagementSystemAPI.Application.Models;
using LibraryManagementSystemAPI.Application.Services.Interfaces;
using LibraryManagementSystemAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace LibraryManagementSystemAPI.Application.Services.Implementaions
{
    public class BorrowService : IBorrowService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public BorrowService(IUnitOfWork unitOfWork, UserManager<User> userManager , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<BorrowDto> CreateAsync(CreateBorrowDto dto , string userId)
        {
            var borrowRepo = _unitOfWork.Repository<Borrow>();
            var borrowExists = await borrowRepo.AnyAsync(a => a.UserId == userId && a.BookId == dto.BookId && a.ReturnDate == null);

            if (borrowExists)
                throw new BadRequestException("User already has an active borrowing for this book.");

            var borrow = _mapper.Map<Borrow>(dto);
            borrow.UserId = userId;

            await borrowRepo.AddAsync(borrow);

            var saveResult = await _unitOfWork.CompleteAsync();

            if (saveResult < 1)
                throw new BadRequestException("Failed to create the borrowing record.");

            return _mapper.Map<BorrowDto>(borrow);   
        }

        public async Task<PagedResult<BorrowDto>> GetBorrowsByUserAsync(string userId , PaginationParams pagination)
        {
            int skip = (pagination.PageNumber - 1) * pagination.PageSize;
            int take = pagination.PageSize;

            Expression<Func<Borrow,bool>> filter = b => b.UserId == userId;

            var borrowRepo = _unitOfWork.Repository<Borrow>();

            var borrow = await borrowRepo.GetPagedResultAsync(filter, skip, take);
            int totalCount = await borrowRepo.CountAsync(filter);

            var borrowDto = _mapper.Map<IEnumerable<BorrowDto>>(borrow);

            return new PagedResult<BorrowDto>
            {
                Data = borrowDto.ToList(),
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<bool> UpdateStatusAsync(Guid id , UpdateBorrowStatusDto dto)
        {
            var borrowRepo = _unitOfWork.Repository<Borrow>();
            var borrow = await borrowRepo.GetByIdAsync(id);

            if (borrow is null)
                throw new NotFoundException("No borrowing found with the provided ID.");

            borrow.Status = dto.Status;
            borrow.ReturnDate = dto.ReturnDate ?? borrow.ReturnDate;

            borrowRepo.Update(borrow);

            var saveResult = await _unitOfWork.CompleteAsync();
            if (saveResult < 1)
                throw new BadRequestException("Failed to update the borrowing status.");

            return true;
        }
    }
}

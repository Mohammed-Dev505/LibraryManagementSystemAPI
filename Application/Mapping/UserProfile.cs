using AutoMapper;
using LibraryManagementSystemAPI.Application.DTOs;
using LibraryManagementSystemAPI.Domain.Entities;

namespace LibraryManagementSystemAPI.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Author,AuthorDto>().ReverseMap();
            CreateMap<Author,CreateAuthorDto>().ReverseMap();
            CreateMap<Author,UpdateAuthorDto>().ReverseMap();
            CreateMap<AuthorDto, CreateAuthorDto>().ReverseMap();
            CreateMap<AuthorDto, UpdateAuthorDto>().ReverseMap();
            CreateMap<CreateAuthorDto, UpdateAuthorDto>().ReverseMap();
            CreateMap<Book,BookDto>().ReverseMap();
            CreateMap<Book,CreateBookDto>().ReverseMap();
            CreateMap<Book,UpdateBookDto>().ReverseMap();
            CreateMap<BookDto, CreateBookDto>().ReverseMap();
            CreateMap<BookDto, UpdateBookDto>().ReverseMap();
            CreateMap<CreateBookDto, UpdateBookDto>().ReverseMap();
            CreateMap<Borrow, BorrowDto>().ForMember(dest => dest.UserName , op => op.MapFrom(s => s.User.UserName)).ReverseMap();
            CreateMap<Borrow, UpdateBorrowStatusDto>().ReverseMap();
            CreateMap<Borrow, CreateBorrowDto>().ReverseMap();
            CreateMap<BorrowDto, UpdateBookDto>().ReverseMap();
            CreateMap<BorrowDto, CreateBorrowDto>().ReverseMap();
            CreateMap<CreateBookDto, UpdateBookDto>().ReverseMap();
            CreateMap<Review,ReviewDto>().ForMember(dest => dest.UserName, op => op.MapFrom(s => s.User.UserName)).ReverseMap();
            CreateMap<Review,CreateReviwDto>().ReverseMap();
            CreateMap<Review,UpdateReviewDto>().ReverseMap();
            CreateMap<ReviewDto, CreateReviwDto>().ReverseMap();
            CreateMap<ReviewDto, UpdateReviewDto>().ReverseMap();
            CreateMap<UpdateReviewDto, CreateReviwDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<User,RegisterUserDto>().ReverseMap();
            CreateMap<RegisterUserDto, UserDto>().ReverseMap();
        }
    }
}

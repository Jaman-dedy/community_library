using AutoMapper;
using CommunityLibrary.Core.Entities;
using CommunityLibrary.Application.DTOs;
using CommunityLibrary.Core.Enums;

namespace CommunityLibrary.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse<UserRole>(src.Role)));
            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Username : null))
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book != null ? src.Book.Title : null))
                .ReverseMap();
            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Username : null))
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book != null ? src.Book.Title : null))
                .ReverseMap();
        }
    }
}
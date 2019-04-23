using System.Linq;
using AutoMapper;
using backend.Dtos;
using backend.Models;

namespace backend.helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<User, UserForListDto>()
        .ForMember(dest => dest.PhotoUrl, opt =>
        {
          opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.isMain).Url);
        })
        .ForMember(dest => dest.Age, opt =>
        {
          opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
        });

      CreateMap<User, UserForDetailedDto>()
        .ForMember(dest => dest.PhotoUrl, opt =>
      {
        opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.isMain).Url);
      })
      .ForMember(dest => dest.Age, opt =>
      {
        opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
      });

      CreateMap<Photo, PhotosForDetailedDto>();
      CreateMap<UserForUpdateDto, User>();
    }
  }
}
using AutoMapper;
using backend.Dtos;
using backend.Models;

namespace backend.helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<User, UserForListDto>();
      CreateMap<User, UserForDetailedDto>();
      CreateMap<Photo, PhotosForDetailedDto>();
    }
  }
}
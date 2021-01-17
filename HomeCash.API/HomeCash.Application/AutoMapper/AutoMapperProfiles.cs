using AutoMapper;
using HomeCash.Application.DTOs;
using HomeCash.Domain.Entities;

namespace HomeCash.Domain.AutoMapperProfiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDTO, User>();
            CreateMap<RegisterDTO, HomeBase>();

        }
    }
}
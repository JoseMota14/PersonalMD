using AutoMapper;
using PersonalMd.Application.DTOs;
using PersonalMd.Domain.Entities;

namespace PersonalMd.Application.Mappings
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile() 
        {
            CreateMap<User, UserDto>();
        }
    }
}

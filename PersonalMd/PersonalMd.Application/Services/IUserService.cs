using PersonalMd.Application.DTOs;
using System;

namespace PersonalMd.Application.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUser(Guid id);
    }
}

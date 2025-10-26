using PersonalMd.Domain.Entities;
using System;

namespace PersonalMd.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid id);
    }
}

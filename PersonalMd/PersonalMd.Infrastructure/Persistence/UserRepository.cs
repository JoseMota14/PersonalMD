using PersonalMd.Domain.Entities;
using PersonalMd.Domain.Interfaces;

namespace PersonalMd.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}

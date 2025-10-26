using PersonalMd.Application.CQRS.Dispatchers;
using PersonalMd.Application.CQRS.Queries;
using PersonalMd.Application.CQRS.Results;
using PersonalMd.Application.DTOs;

namespace PersonalMd.Application.Services.Imp
{
    public class UserService : IUserService
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public UserService(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        public async Task<UserDto> GetUser(Guid id)
        {
            var ret = await _queryDispatcher.Dispatch<GetUserById, Result<UserDto>>(new GetUserById(id));
            
            if(ret.Error is not null)
            {
                throw new Exception(ret.Error);
            }

            return ret?.Value!;
        }
    }
}

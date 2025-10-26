using AutoMapper;
using PersonalMd.Application.CQRS.Handlers;
using PersonalMd.Application.CQRS.Queries;
using PersonalMd.Application.CQRS.Results;
using PersonalMd.Application.DTOs;
using PersonalMd.Domain.Interfaces;

namespace PersonalMd.Application.CQRS
{
    public class UserQueryHandler : IQueryHandler<GetUserById, Result<UserDto>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserQueryHandler(IUserRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<UserDto>> Handle(GetUserById query)
        {
            var user = await _repository.GetById(query.UserId);

            if(user == null)
            {
                return Result<UserDto>.Fail("User not found", ResultStatus.NotFound);
            }

            var dto = _mapper.Map<UserDto>(user);
            return Result<UserDto>.Success(dto);    
        }
    }
}

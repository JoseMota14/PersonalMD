using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalMd.Application.CQRS;
using PersonalMd.Application.CQRS.Dispatchers;
using PersonalMd.Application.CQRS.Handlers;
using PersonalMd.Application.CQRS.Queries;
using PersonalMd.Application.CQRS.Results;
using PersonalMd.Application.DTOs;
using PersonalMd.Application.Mappings;
using PersonalMd.Application.Services;
using PersonalMd.Application.Services.Imp;
using PersonalMd.Domain.Interfaces;
using PersonalMd.Infrastructure.Persistence;

namespace PersonalMd.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterRepo(services);

            RegisterServices(services);

            RegisterHandlers(services);

            services.AddAutoMapper(typeof(DomainToDTOProfile));

            return services;
        }

        private static void RegisterRepo(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("PersonalMdDb"));

            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        private static void RegisterHandlers(IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<GetUserById, Result<UserDto>>, UserQueryHandler>();

            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        }
    }
}

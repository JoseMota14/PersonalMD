using Microsoft.Extensions.DependencyInjection;
using PersonalMd.Application.CQRS.Handlers;

namespace PersonalMd.Application.CQRS.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider; 

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query)
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return await handler.Handle(query);

        }
    }
}

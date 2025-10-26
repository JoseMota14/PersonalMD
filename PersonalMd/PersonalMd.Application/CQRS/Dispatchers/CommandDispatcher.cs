using Microsoft.Extensions.DependencyInjection;
using PersonalMd.Application.CQRS.Handlers;

namespace PersonalMd.Application.CQRS.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> Dispatch<TCommand, TResult>(TCommand command)
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand,TResult>>();
            return await handler.Handle(command);
        }
    }
}

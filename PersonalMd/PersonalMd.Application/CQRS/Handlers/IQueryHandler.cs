using PersonalMd.Application.CQRS.Results;
using System;

namespace PersonalMd.Application.CQRS.Handlers
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}

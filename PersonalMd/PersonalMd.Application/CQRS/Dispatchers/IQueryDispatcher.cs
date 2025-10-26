

namespace PersonalMd.Application.CQRS.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query);
    }
}

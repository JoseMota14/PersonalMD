

namespace PersonalMd.Application.CQRS.Queries
{
    public class GetUserById
    {
        public Guid UserId { get; set; }

        public GetUserById(Guid userId)
        {
            UserId = userId;
        }
    }
}

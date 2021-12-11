using Domain.Entities;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure.Persistence.Query;

public class ChatQuery : QueryBase<Chat>

{
    public ChatQuery(IUnitOfWorkProvider provider) : base(provider) { }

    public ChatQuery FilterByMember(int userId)
    {
        Queryable = Queryable.Where(c => c.MemberOneId == userId || c.MemberTwoId == userId);
        return this;
    }
}
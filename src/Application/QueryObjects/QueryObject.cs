using Domain.Interfaces;

namespace Application.QueryObjects
{
    public abstract class QueryObject
    {
        public IUnitOfWork UnitOfWork { get; }
        
        protected QueryObject(IUnitOfWork unit)
        {
            UnitOfWork = unit;
        }

    }
}
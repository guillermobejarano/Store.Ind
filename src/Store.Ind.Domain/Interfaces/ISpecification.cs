using System;
using System.Linq.Expressions;

namespace Store.Ind.Domain.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}
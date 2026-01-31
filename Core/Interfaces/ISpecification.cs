using System;
using System.IO.Pipelines;
using System.Linq.Expressions;
using Core.Specifications;

namespace Core.Interfaces;

public interface ISpecification<T>

{
    Expression<Func<T,bool>>? Criteria {get;}
    Expression<Func<T,object>>? OrderBy {get;}
    Expression<Func<T,object>>? OrderByDescending {get;}

    bool IsDistinct {get;}

}
public interface ISpecification<T,TResult> : ISpecification<T>

{
    Expression<Func<T,TResult>>? Select {get;}

}

public class BaseSpecification<T,TResult>(Expression<Func<T,bool>> criteria) : BaseSpecification<T>(criteria), ISpecification<T,TResult>
{
    public Expression<Func<T,TResult>>? Select {get; private set;}
    protected void AddSelect(Expression<Func<T,TResult>> selectExpression)
    {
        Select = selectExpression;
    }
}


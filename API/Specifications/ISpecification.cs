using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Specification
{
    public interface ISpecification<T>
    {
         Expression<Func<T, bool>> Criteria {get; }
         List<Expression<Func<T, object>>> Includes {get; }


        // Sorting with Generics and Spec Patern
         Expression<Func<T, object>> OrderBy {get;}
         Expression<Func<T, object>> OrderByDecending {get;}

         int Take {get;}
         int Skip {get;}
         bool IsPagingEnabled {get;}
         
    }
}
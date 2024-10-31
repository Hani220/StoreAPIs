using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification
{
    public interface ISpecification <T>
    {
        Expression <Func<T,bool>> Criteria { get; } 
        //for where conditions


        
        List <Expression<Func<T,Object>>> Includes { get; }
        // for includes

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }


        //Pagination

        int Take { get; }   

        int Skip { get; }

        bool IsPaginated { get; }
    }
}

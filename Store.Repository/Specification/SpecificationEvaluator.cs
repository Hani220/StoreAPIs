using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification
{
    public  class SpecificationEvaluator <TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> GetQuery (IQueryable<TEntity> inputQuery ,ISpecification<TEntity> specifications)
        {
            var query = inputQuery;

            if (specifications.Criteria is not null) 
            {
                query = query.Where(specifications.Criteria);
            }

            if(specifications.OrderBy is not null)
            {
                query = query.OrderBy(specifications.OrderBy);
            } 
            
            if(specifications.OrderByDescending is not null)
            {
                query = query.OrderBy(specifications.OrderByDescending);
            }

            if (specifications.IsPaginated)
            {
                query = query.Skip(specifications.Skip).Take(specifications.Take);
            }
            query = specifications.Includes.Aggregate(query,(Current, includeEx)=> Current.Include(includeEx));

            return query;
        }
    }
}

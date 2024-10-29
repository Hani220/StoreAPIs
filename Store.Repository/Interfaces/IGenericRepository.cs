using Store.Data.Entities;
using Store.Repository.Specification;
using Store.Repository.Specification.ProductSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IGenericRepository <TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey? id);

        Task<IReadOnlyList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdWithSpecificationAsync(ISpecification<TEntity> specifications);

        Task<IReadOnlyList<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity> specifications);

        Task AddAsync (TEntity entity);

       void Update (TEntity entity);    

       void Delete (TEntity entity);
    }
}

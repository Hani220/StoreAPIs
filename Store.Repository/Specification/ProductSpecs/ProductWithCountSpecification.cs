using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification.ProductSpecs
{
   public  class ProductWithCountSpecification : BaseSpecification<Product>
    {
        public ProductWithCountSpecification(ProductSpecification specification) :
               base(prod => (!specification.BrandId.HasValue || prod.BrandId == specification.BrandId.Value) &&
                           (!specification.TypeId.HasValue || prod.TypeId == specification.TypeId.Value) &&
            (string.IsNullOrEmpty(specification.Search) || prod.Name.Trim().ToLower().Contains(specification.Search)))
        {

        }
    }
}

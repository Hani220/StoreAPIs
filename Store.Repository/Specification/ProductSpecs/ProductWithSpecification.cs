using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification.ProductSpecs
{
    public class ProductWithSpecification :BaseSpecification<Product>
    {
        public ProductWithSpecification(ProductSpecification specification):
            base (prod =>(!specification.BrandId.HasValue|| prod.BrandId == specification.BrandId.Value) &&
                        (!specification.TypeId.HasValue || prod.TypeId == specification.TypeId.Value)&&
            (string.IsNullOrEmpty(specification.Search) || prod.Name.Trim().ToLower().Contains(specification.Search))
            )

        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);
            AddOrederBy(x => x.Name);

            ApplyPagination(specification.PageSize * (specification.PageIndex - 1), specification.PageSize);

            if(!string.IsNullOrEmpty(specification.Sort))
            {
                switch(specification.Sort)
                {
                    case "PriceASC":
                        AddOrederBy(x => x.Price);
                        break;
                    case "PriceDESC":
                        AddOrederByDescending(x => x.Price);
                        break;
                    default:
                        AddOrederBy(x => x.Name);
                        break;
                }
            }
            
        }

        public ProductWithSpecification(int?id) :base (prod => prod.Id == id)
        {
            AddInclude (x => x.Brand);

            AddInclude (x => x.Type);
        }
    }
}

using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Specifications
{
    public class ProductWithTypesSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesSpecification(ProductSpecParams productParams)
              : base(x =>
                  (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                  (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
              )
        {
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductWithTypesSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
        }


    }
}

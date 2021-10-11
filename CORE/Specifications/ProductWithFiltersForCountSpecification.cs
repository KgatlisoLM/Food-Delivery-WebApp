using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
        : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
        )
        {
        }
    }
}

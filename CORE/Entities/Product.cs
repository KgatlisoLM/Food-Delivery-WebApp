using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string DeliveryTime { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
    }
}

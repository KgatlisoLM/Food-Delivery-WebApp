using AutoMapper;
using CORE.Entities;
using FDDAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDDAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<ProductType, TypesToReturnDto>()
                .ForMember(c =>c.ImageUrl, o =>o.MapFrom<TypeUrlResolver>());
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            
     
       
        }
    }
}

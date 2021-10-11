using AutoMapper;
using CORE.Entities;
using FDDAPI.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDDAPI.Helpers
{
    public class TypeUrlResolver : IValueResolver<ProductType, TypesToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public TypeUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(ProductType source, TypesToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _config["ApiUrl"] + source.ImageUrl;
            }

            return null;
        }
    }
}

using AutoMapper;
using CORE.Entities;
using CORE.Interfaces;
using CORE.Specifications;
using FDDAPI.Dtos;
using FDDAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepo<Product> _productRepo;
        private readonly IGenericRepo<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepo<Product> productRepo, IGenericRepo<ProductType> productTypeRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
        [FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductWithTypesSpecification(productParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await _productRepo.CountAsync(countSpec);

            var products = await _productRepo.ListAsync(spec);

            var data = _mapper
                .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypesSpecification(id);

            var product = await _productRepo.GetEntityWithSpec(spec);

            //if (product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<TypesToReturnDto>>> GetProductTypes()
        {
            var _types = await _productTypeRepo.ListAllAsync();
            var data = _mapper.Map<IReadOnlyList<ProductType>, List<TypesToReturnDto>>(_types);
            return data;
        }
    }
}

using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Specification.ProductSpecs;
using Store.Service.Helper;
using Store.Service.Services.Products;
using Store.Service.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services
{
    public class ProductService :IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<PaginatedResultDto<ProductDto>> GetAllProductsAsync(ProductSpecification input)
        {
            var specifications = new ProductWithSpecification(input);

            var products = await _unitOfWork.Repository<Product, int>().GetAllWithSpecificationAsync(specifications);

            var mappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);

            var countSpecifications =  new ProductWithCountSpecification(input);

            var count = await _unitOfWork.Repository<Product, int>().GetCountWithSpecification(specifications);

            return new PaginatedResultDto<ProductDto>(input.PageIndex ,input.PageSize,count,mappedProducts);

        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
           var brands = await _unitOfWork.Repository<ProductBrand,int>().GetAllAsync();

            var mappedBrands = _mapper.Map <IReadOnlyList<BrandTypeDetailsDto>>(brands);
            return mappedBrands;
        }

        //public  async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync()
        //{
           
        //   var products = await _unitOfWork.Repository<Product,int>().GetAllAsync();

        //    var mappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);

        //    return mappedProducts;

        //}

        


       public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType,int>().GetAllAsync();

            var mappedTypes = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(types);
            return mappedTypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int? id)
        {
            if(id == null)
            {
                throw new Exception("Id is Null");

            }
            var specifications = new ProductWithSpecification(id);
            var product = await _unitOfWork.Repository<Product, int>().GetByIdWithSpecificationAsync(specifications);
              
            if (product == null)
            {
                throw new Exception("Product Not Found");

            }

            var mappedProduct = _mapper.Map<ProductDto>(product);

            return mappedProduct;
        }
    }
}

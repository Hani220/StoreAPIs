﻿using Store.Data.Entities;
using Store.Repository.Interfaces;
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

        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
           var brands = await _unitOfWork.Repository<ProductBrand,int>().GetAllAsync();

            IReadOnlyList<BrandTypeDetailsDto> mappedBrands = brands.Select(b => new BrandTypeDetailsDto
            {
                Id = b.Id,
                Name = b.Name,
                CreatedAt = b.CreatedAt


            }).ToList();

            return mappedBrands;
        }

        public  async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync()
        {
           var products = await _unitOfWork.Repository<Product,int>().GetAllAsync();

            var mappedProducts = products.Select(b => new ProductDto
            {
                Id = b.Id,
                Name = b.Name,
                BrandName = b.Brand.Name,
                TypeName = b.Type.Name,
                CreatedAt = b.CreatedAt,
                Description = b.Description,
                PictureUrl = b.PictureUrl
            }).ToList();

            return mappedProducts;


        }


       public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType,int>().GetAllAsync();

            var mappedTypes = types.Select(b => new BrandTypeDetailsDto
            {
                Id = b.Id,
                Name = b.Name,
                CreatedAt= b.CreatedAt,
                
            }).ToList();

            return mappedTypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int? id)
        {
            if(id == null)
            {
                throw new Exception("Id is Null");

            }

            var product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(id.Value);
              
            if (product == null)
            {
                throw new Exception("Product Not Found");

            }

            var mappedProduct = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                CreatedAt = product.CreatedAt,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,  
                TypeName = product.Type.Name,
                BrandName = product.Brand.Name

            };

            return mappedProduct;
        }
    }
}

using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Data.Entities;
using Store.Service.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services
{
    public class ProductImageResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductImageResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(source.PictureUrl)) 
            {
                return $"{_configuration["BaseUrl"]}/{source.PictureUrl}";
            }
            return null;
        }
    }
}

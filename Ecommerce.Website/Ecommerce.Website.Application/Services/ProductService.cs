﻿using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Application.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<Product> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1)
        {
            return _productRepository.GetAll(search,from,to,sortBy,page);
        }
    }
}

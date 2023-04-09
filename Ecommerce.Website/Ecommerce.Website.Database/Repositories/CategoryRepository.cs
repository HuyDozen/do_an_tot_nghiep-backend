using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Data;
using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly EcommerceContext _context;
        public CategoryRepository(EcommerceContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductByOrderViewModel> GetProductsByCategory()
        {
            List<Product> products = _context.Products.ToList();
            List<Category> categories = _context.Categories.ToList();

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var joinedData = categories
                .GroupJoin(products, u => u.Id, c => c.CategoryId, (u, c) =>
                new {id = u.Id, Products = products });

            if(joinedData != null)
            {
                var result = new List<ProductByOrderViewModel>();
                foreach (var items in joinedData)
                {
                    var prods = new List<Product>();
                    foreach (var prod in items.Products)
                    {
                        var product = new Product()
                        {
                            Id = prod.Id,
                            Title = prod.Title,
                            Image = prod.Image,
                            Images = prod.Images,
                            Description = prod.Description,
                            Price = prod.Price,
                            Quanity = prod.Quanity,
                            ShortDesc = prod.ShortDesc
                        };
                        prods.Add(product);
                    }
                    var resultVIew = new ProductByOrderViewModel()
                    {
                        Id = items.id,
                        Products = prods
                    };
                    result.Add(resultVIew);
                }
                return result;
            }
            else
            {
                return null;
            }   
        }
    }
}

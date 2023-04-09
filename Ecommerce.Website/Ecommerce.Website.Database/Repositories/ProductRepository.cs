using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Data;
using Ecommerce.Website.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly EcommerceContext _context;
        public static int Page_Size { get; set; } = 8;
        public ProductRepository(EcommerceContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll(string? search,double? from, double? to, string? sortBy, int page = 1)
        {
            var allProducts = _context.Products.AsQueryable();

            #region filtering
            if (!string.IsNullOrEmpty(search))
            {
               allProducts = allProducts.Where(
               hh => hh.Title.Contains(search));

            }
            if (from.HasValue)
            {
                allProducts = allProducts.Where(hh =>hh.Price >= from);
            }
            if (to.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.Price <= to);
            }
            #endregion

            #region Sorting
            //Mac dinh sort theo ten
            allProducts =allProducts.OrderBy(hh => hh.Title);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.Title);
                        break;
                    case "price_asc":
                        allProducts = allProducts.OrderBy(hh => hh.Price);
                        break;
                    case "price_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.Price);
                        break;

                }
            }
            #endregion

            #region Paging
            allProducts = allProducts.Skip((page - 1) * Page_Size).Take(Page_Size);
            #endregion

            var result = allProducts.Select(hh => new Product
            {
                Id = hh.Id,
                Title = hh.Title,
                Image = hh.Image,
                Images = hh.Images,
                Price = hh.Price,
                Quanity = hh.Quanity,
                ShortDesc = hh.ShortDesc,
                CategoryId = hh.CategoryId,
                Description = hh.Description

            });

            return result;

            //var result = PaginatedList <Ecommerce.Website.Database.Models.Product >.Create(allProducts, page, Page_Size);
            //return result.Select(hh => new Product
            //{
            //    Title = hh.Title,
            //    Image = hh.Image,
            //    Images = hh.Images,
            //    Price = hh.Price,
            //    Quanity = hh.Quanity,
            //    ShortDesc = hh.ShortDesc,


            //});
        }
    }
}

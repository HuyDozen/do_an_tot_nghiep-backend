using Ecommerce.Website.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Application.Contacts
{
    public interface IProductService : IBaseService<Product>
    {
        IEnumerable<Product> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1);
    }
}

using Ecommerce.Website.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Contacts
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IEnumerable<Product> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1);
    }

    
}

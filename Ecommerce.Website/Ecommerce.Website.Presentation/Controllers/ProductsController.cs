using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Website.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BasesController<Product>
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService) : base(productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("Products/SeachPr")]
        public IActionResult GetAllProducts(
            string? search,
            double? from, 
            double? to, 
            string? sortBy,
            int page = 1)
        {
            try
            {
                var records = _productService.GetAll(search,from,to,sortBy,page);

                //var config = new MapperConfiguration(cfg => cfg.CreateMap<T, >());
                //var mapper = config.CreateMapper();
                //var recordsDto = mapper.Map<List<UserDto>>(records);

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }
    }   
}

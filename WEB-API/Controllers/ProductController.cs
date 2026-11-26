using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<List<Product>> Get(
                [FromQuery] int position,
                [FromQuery] int skip,
                [FromQuery] string? desc,
                [FromQuery] int?[] categoryIds,
                [FromQuery] int minPrice,
                [FromQuery] int maxPrice)
        {         

           return await _productService.GetAllProducts(position, skip, desc, categoryIds, minPrice, maxPrice);

           

        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

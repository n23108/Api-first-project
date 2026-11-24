using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoriesService.GetAllCategories();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            return await _categoriesService.GetCategory(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task Post([FromBody] Category category)
        {
            await _categoriesService.AddCategory(category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Category category)
        {
            await _categoriesService.UpdateCategory(id, category);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryServices _categoryservices;

        public CategoriesController(ICategoryServices categoryservices)
        {
            _categoryservices = categoryservices;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);
            var result = _categoryservices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
    }
}

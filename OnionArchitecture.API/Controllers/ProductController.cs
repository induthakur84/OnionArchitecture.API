using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Data.Services.IServices;
using OnionArchitecture.DTO;

namespace OnionArchitecture.API.Controllers
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


        // GET: api/Product/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }


        /// GET: api/Product/GetById/1

        [HttpGet("GetById/{id}")]

        public async Task<ActionResult<ProductReadDto>> GetById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }



        /// <summary>
        /// Command and query architecture        /// </summary>
        /// <param name="productCreateDto"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<ActionResult<ProductReadDto>> Create(ProductCreateDto productCreateDto)
        {

            // here we can give the command
            var product = await _productService.Create(productCreateDto);
            return Ok(product);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ProductReadDto>> Update(ProductUpdateDto productUpdateDto)
        {
            var product = await _productService.Update(productUpdateDto);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var isDeleted = await _productService.Delete(id);
            if (!isDeleted)
            {
                return false;
            }
            return true;
        }
    }
}

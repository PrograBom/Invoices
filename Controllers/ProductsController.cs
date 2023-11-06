using Invoices.Exceptions;
using Invoices.Handler;
using Invoices.Model;
using Invoices.Services;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Dtos
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapperService<Product, ResponseProductDto> _productMapper;
        private readonly IMapperService<IEnumerable<Product>, ResponseProductListDto> _productListMapper;

        public ProductsController(IMapperService<Product, ResponseProductDto> productMapper, IMapperService<IEnumerable<Product>, ResponseProductListDto> productListMapper, IProductService productService)
        {
            _productMapper = productMapper;
            _productListMapper = productListMapper;
            _productService = productService;
        }

        [HttpPost]
        [HttpPut]
        public async Task<ActionResult<ResponseProductDto>> SaveProduct([FromBody] SaveProductDto productRequest)
        {
            if (productRequest == null)
            {
                return BadRequest();
            }

            try
            {
                Product product = await _productService.SaveProductAsync(productRequest);
                return Ok((ResponseProductDto)product);
            }
            catch (CustomException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public ActionResult DeleteProduct([FromQuery] int id)
        {
            if(id == 0) { return BadRequest(); };
            _productService.DeleteProduct(id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ResponseProductDto>> GetProductByIdAsync([FromQuery] int id)
        {
            if (id == 0) return BadRequest();

            try
            {
                Product product = await _productService.GetProductByIdAsync(id);
                return Ok((_productMapper.Map(product)));
            }
            catch (CustomException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex); ;
            }
        }

        [HttpGet("list")]
        public async Task<ResponseProductListDto> GetProductListAsync()
        {
            var products = await _productService.GetProductListAsync();
            return _productListMapper.Map(products);
        }
    }
}
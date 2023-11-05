using Invoices.Exceptions;
using Invoices.Model;
using Invoices.Services;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Dtos
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
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
    }
}
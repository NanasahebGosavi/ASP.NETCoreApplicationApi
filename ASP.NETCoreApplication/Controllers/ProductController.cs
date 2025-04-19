using ASP.NETCoreApplication.Entities;
using ASP.NETCoreApplication.Interface;
using ASP.NETCoreApplication.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productservice;

        public ProductController(IProduct productservice)
        {

            _productservice = productservice;
        }


        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var ProductList = await _productservice.GetAllProduct();
            return Ok(ProductList);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var CreatedProduct = await _productservice.AddProduct(product);
            return Ok(CreatedProduct);

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            var updatedProduct = await _productservice.UpdateProduct(id,product);
            if (updatedProduct == null) return NotFound();

            return Ok(updatedProduct);

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {


            var deleteproduct = await _productservice.DeleteProduct(id);

            if (!deleteproduct )
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> GetProductById(int id, [FromBody] JsonPatchDocument<Product> PatchDoc)
        {

            if(PatchDoc== null)
            {
                return BadRequest();
            }
            try
            {
                var productData = await _productservice.GetProductById(id);
                if (productData == null)
                {
                    return NotFound();
                }
                PatchDoc.ApplyTo(productData, ModelState);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                await _productservice.UpdateProduct(id, productData);
                return Ok(productData);
            }
            catch(ArgumentException ax)
            {
                return BadRequest(new 
                {
                    Message ="Invalid Parameter ",
                    Detail=ax.Message
                });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new
                {
                    Message = "Internal Error ",
                    Detail = ex.Message
                });
            }
           
        }

        [HttpPatch]
        public async Task<IActionResult> PartialUpdate(int id, [FromBody] JsonPatchDocument<Product> PatchDoc)
        {

            if (PatchDoc == null)
            {
                return BadRequest();
            }
            var productData = await _productservice.GetProductById(id);
            if (productData == null)
            {
                return NotFound(); 
            }
            PatchDoc.ApplyTo(productData, ModelState);
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }


            await _productservice.UpdateProduct(id, productData);
            return Ok(productData);
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMdevAPI.Data;
using SIMdevAPI.Models;

namespace SIMdevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_Details_Controller : ControllerBase
    {
        private readonly SimDataContext dbcontext;
        public Product_Details_Controller(SimDataContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Details>>> GetAllProdDetails()
        {
            return await dbcontext.prod_details.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddProdDetails(Product_Details_DTO product)
        {
            var prod_details = new Product_Details()
            {
                Prod_Mast_Id = product.Prod_Mast_Id,
                Prod_Name = product.Prod_Name,
                Comp_Details_Id = product.Comp_Details_Id,
                Qty = product.Qty
            };
            await dbcontext.prod_details.AddAsync(prod_details);
            await dbcontext.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProdDetails([FromRoute] long id, Product_Details_DTO product)
        {
            var findId = await dbcontext.prod_details.FindAsync(id);
            if (findId != null)
            {

                findId.Prod_Mast_Id = product.Prod_Mast_Id;
                    findId.Prod_Name = product.Prod_Name;
                    findId.Comp_Details_Id = product.Comp_Details_Id;
                    findId.Qty = product.Qty;
              
                await dbcontext.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProdDetails([FromRoute] long id)
        {
            var findId = await dbcontext.prod_details.FindAsync(id);
            if (findId != null)
            {
                dbcontext.prod_details.Remove(findId);
                await dbcontext.SaveChangesAsync();
                return Ok(findId);
            }
            return NotFound();
        }
    }
}

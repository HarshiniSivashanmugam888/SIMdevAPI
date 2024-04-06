using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMdevAPI.Data;
using SIMdevAPI.Models;

namespace SIMdevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_Master_Controller : ControllerBase
    {
        private readonly SimDataContext dbcontext;
        public Product_Master_Controller(SimDataContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Master>>> GetAllProdMaster()
        {
            return await dbcontext.prod_mast.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddProdMaster(Product_Master_DTO product)
        {
            var prod_mast = new Product_Master()
            {
                Prod_Name = product.Prod_Name
            };
            await  dbcontext.prod_mast.AddAsync(prod_mast);
            await dbcontext.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProdMaster([FromRoute] long id, Product_Master_DTO product)
        {
            var findId = dbcontext.prod_mast.FirstOrDefault(s => s.Prod_Mast_Id == id);
            if (findId != null)
            {
                findId.Prod_Name = product.Prod_Name;
                await dbcontext.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProdMast([FromRoute] long id)
        {
            var findId = await dbcontext.prod_mast.FindAsync(id);
            if(findId!= null)
            {
                dbcontext.prod_mast.Remove(findId);
                await dbcontext.SaveChangesAsync();
                return Ok(findId);
            }
            return NotFound();
        }
    }
}

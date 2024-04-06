using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMdevAPI.Data;
using SIMdevAPI.Models;

namespace SIMdevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Spares_Out_For_Production_Controller : ControllerBase
    {
        private readonly SimDataContext dbcontext;
        public Spares_Out_For_Production_Controller(SimDataContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spares_Out_For_Production>>> GetSparesOutForProduction()
        {
            return await dbcontext.spares_out_for_production.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddSparesOutForProduction(Spares_Out_For_Production_DTO spares)
        {
            var spares_out = new Spares_Out_For_Production()
            {
                Comp_Details_Id = spares.Comp_Details_Id,
                Prod_Mast_Id = spares.Prod_Mast_Id,
                Staff_Id = spares.Staff_Id,
                Qty = spares.Qty,
                Date = DateTime.Now
            };

            await dbcontext.spares_out_for_production.AddAsync(spares_out);
            await dbcontext.SaveChangesAsync();
            return Ok(spares);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSparesOutForProduction([FromRoute] long id, Spares_Out_For_Production_DTO spares)
        {
            var findId = await dbcontext.spares_out_for_production.FindAsync(id);
            if (findId != null)
            {
                findId.Comp_Details_Id = spares.Comp_Details_Id;
                findId.Prod_Mast_Id = spares.Prod_Mast_Id;
                findId.Staff_Id = spares.Staff_Id;
                findId.Qty = spares.Qty;
                findId.Date = DateTime.Now;
            }
            await dbcontext.SaveChangesAsync();
            return Ok(spares);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSparesOutForProduction([FromRoute] long id)
        {
            var findId = await dbcontext.spares_out_for_production.FindAsync(id);
            if(findId != null)
            {
                dbcontext.spares_out_for_production.Remove(findId);
                return Ok(findId);
            }
            return NotFound();
        }

    }
}

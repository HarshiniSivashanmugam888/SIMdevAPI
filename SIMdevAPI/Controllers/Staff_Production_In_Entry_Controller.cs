using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMdevAPI.Data;
using SIMdevAPI.Models;

namespace SIMdevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Staff_Production_In_Entry_Controller : ControllerBase
    {
        private readonly SimDataContext dbcontext;
        public Staff_Production_In_Entry_Controller(SimDataContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff_Production_In_Entry>>> GetStaff_Prod_In_Entry()
        {
            return await dbcontext.staff_prod_in_entry.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff_Prod_In_Entry(Staff_Production_In_Entry_DTO entry)
        {
            var staff_entry = new Staff_Production_In_Entry()
            {
                Prod_Mast_Id = entry.Prod_Mast_Id,
                Staff_Id = entry.Staff_Id,
                Date = DateTime.Now,
                Qty = entry.Qty
            };
            await dbcontext.staff_prod_in_entry.AddAsync(staff_entry);
            await dbcontext.SaveChangesAsync();
            return Ok(entry);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStaff_Prod_In_Entry([FromRoute] long id,Staff_Production_In_Entry_DTO entry)
        {
            var findId = await dbcontext.staff_prod_in_entry.FindAsync(id);
            if(findId!= null)
            {
                findId.Staff_Id = entry.Staff_Id;
                findId.Date = DateTime.Now;
                findId.Prod_Mast_Id = entry.Prod_Mast_Id;
                findId.Qty = entry.Qty;

                await dbcontext.SaveChangesAsync();
                return Ok(entry);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStaff_Prod_In_Entry([FromRoute] long id)
        {
            var findId = await dbcontext.staff_prod_in_entry.FindAsync(id);
            if(findId!= null)
            {
                dbcontext.staff_prod_in_entry.Remove(findId);
                await dbcontext.SaveChangesAsync();
                return Ok(findId);
            }
            return NotFound();
        }

    }
}

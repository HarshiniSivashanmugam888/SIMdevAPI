using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMdevAPI.Data;
using SIMdevAPI.Models;
using System.Runtime.InteropServices;

namespace SIMdevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Component_Details_Controller : ControllerBase
    {
        private readonly SimDataContext dbcontext;
        public Component_Details_Controller(SimDataContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Component_Details>>> GetllAllComponentDetails()
        {
            return await dbcontext.comp_details.ToListAsync();            
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Component_Details>>> AddNewComponentDetails(Component_Details_DTO component)
        {
            var comp_details = new Component_Details()
            {
                Comp_Mast_Id = component.Comp_Mast_Id,
                Comp_Details_Name = component.Comp_Details_Name,
                Unit = component.Unit,
                Value = component.Value
            };
            await dbcontext.comp_details.AddAsync(comp_details);
            await dbcontext.SaveChangesAsync();

            return Ok(component);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateComponentDetails([FromRoute] long id, Component_Details_DTO component)
        {
            var FindId = await dbcontext.comp_details.FindAsync(id);
            if (FindId != null)
            {
                FindId.Comp_Details_Name = component.Comp_Details_Name;
                FindId.Unit = component.Unit;
                FindId.Value = component.Value;
                await dbcontext.SaveChangesAsync();
                return Ok(component);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteComponentDetails([FromRoute] long id)
        {
            var findId = await dbcontext.comp_details.FindAsync(id);
            if(findId!= null)
            {
                 dbcontext.comp_details.Remove(findId);
                await dbcontext.SaveChangesAsync();
                return Ok(findId);
            }
            return NotFound();
        }
    }
}

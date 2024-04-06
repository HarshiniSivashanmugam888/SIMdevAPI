using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMdevAPI.Data;
using SIMdevAPI.Models;

namespace SIMdevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Staff_Master_Cotroller : ControllerBase
    {

        private readonly SimDataContext dbcontext;
        public Staff_Master_Cotroller(SimDataContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff_Master>>> GetAllStaffs()
        {
            return await dbcontext.staff_master.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(Staff_Master_DTO staff)
        {
            var staff_mast = new Staff_Master()
            {
                Staff_Name = staff.Staff_Name,
                First_Name = staff.First_Name,
                Last_Name = staff.Last_Name,
                Employee_Id = staff.Employee_Id,
                Designation = staff.Designation
            };
            await dbcontext.staff_master.AddAsync(staff_mast);
            await dbcontext.SaveChangesAsync();
            return Ok(staff);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStaffMaster([FromRoute] long id, Staff_Master_DTO staff)
        {
            var findId = await dbcontext.staff_master.FindAsync(id);
            if(findId != null)
            {
                findId.Staff_Name = staff.Staff_Name;
                findId.First_Name = staff.First_Name;
                findId.Last_Name = staff.Last_Name;
                findId.Employee_Id = staff.Employee_Id;
                findId.Designation = staff.Designation;

                await dbcontext.SaveChangesAsync();
                return Ok(staff);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStaffMaster([FromRoute] long id)
        {
            var findId = await dbcontext.staff_master.FindAsync(id);
            if(findId != null)
            {
                dbcontext.staff_master.Remove(findId);
                await dbcontext.SaveChangesAsync();
                return Ok(findId);
            }
            return NotFound();
        }
    }
}

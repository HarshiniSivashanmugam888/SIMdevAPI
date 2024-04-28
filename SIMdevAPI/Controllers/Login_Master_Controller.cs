using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMdevAPI.Data;
using SIMdevAPI.Models;

namespace SIMdevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login_Master_Controller : ControllerBase
    {
        private readonly SimDataContext dbcontext;
        public Login_Master_Controller(SimDataContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login_Master>>> GetAllLoginDetails()
        {
            return await dbcontext.login_master.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult<Login_Master_DTO>> AddNewUser([FromBody]Login_Master_DTO user)
        {
            var new_user = new Login_Master() {
                username = user.username,
                password = user.password
            };

            await dbcontext.login_master.AddAsync(new_user);
            await dbcontext.SaveChangesAsync();
            return Ok(new_user);

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Login_Master_DTO>> UpdateLoginDetails([FromRoute] long id, Login_Master_DTO user)
        {
            var findId = await dbcontext.login_master.FindAsync(id);
            if (findId != null)
            {
                findId.username = user.username;
                findId.password = user.password;
                await dbcontext.SaveChangesAsync();
                return Ok(findId);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Login_Master_DTO>> DeleteLoginDetails([FromRoute] long id)
        {
            var findId = await dbcontext.login_master.FindAsync(id);
            if (findId != null)
            {
                dbcontext.login_master.Remove(findId);
                await dbcontext.SaveChangesAsync();
                return Ok(findId);
            }
            else { return NotFound(); }
        }


    }
}

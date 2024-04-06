using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMdevAPI.Data;
using SIMdevAPI.Models;

namespace SIMdevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Component_Master_Controller : ControllerBase
    {
        private readonly SimDataContext dbcontext;
        public Component_Master_Controller(SimDataContext simdbcontext) {
            dbcontext = simdbcontext;
        }

        [HttpGet]
        public ActionResult<Component_Master> GetAllMastComponents()
        {
            return Ok(dbcontext.comp_mast.ToList());
        }

        [HttpPost]
        public IActionResult AddNewCompMast(Component_Master_DTO component)
        {
            var comp_mast = new Component_Master()
            {
                Comp_Mast_Name = component.Comp_Mast_Name,
                Unit = component.Unit,
                Value = component.Value,
                Min_Qty = component.Min_Qty
            };

            dbcontext.comp_mast.Add(comp_mast);
            dbcontext.SaveChanges();
            return Ok(comp_mast);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCompMast([FromRoute] long id,Component_Master_DTO componet)
        {
            var findId = dbcontext.comp_mast.Find(id);
            if (findId!= null)
            {
                findId.Comp_Mast_Name = componet.Comp_Mast_Name;
                findId.Unit = componet.Unit;
                findId.Value = componet.Value;
                findId.Min_Qty = componet.Min_Qty;
                dbcontext.SaveChanges();
                return Ok(findId);

            }

            return NotFound();            

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCompMast([FromRoute] long id)
        {
            var findId = dbcontext.comp_mast.Find(id);
            if (findId != null)
            {
                dbcontext.comp_mast.Remove(findId);
                dbcontext.SaveChanges();
                return Ok(findId);
            }
            return NotFound();
        }
    }
}

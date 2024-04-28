using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMdevAPI.Data;
using SIMdevAPI.Models;

namespace SIMdevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Stock_Master_Controller : ControllerBase
    {
        private readonly SimDataContext dbcontext;
        public Stock_Master_Controller(SimDataContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock_Master>>> GetAllStocks()
        {
            return await dbcontext.stock_master.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddStock(Stock_Master_DTO stock)
        {
            var stock_mast = new Stock_Master()
            {
                Comp_Details_Id = stock.Comp_Details_Id,
                Date = stock.Date,
                Qty = stock.Qty,
                Price = stock.Price,
                Box_Unit = stock.Box_Unit,
                Buyer_Name = stock.Buyer_Name               
            };
            await dbcontext.stock_master.AddAsync(stock_mast);
            await dbcontext.SaveChangesAsync();
            return Ok(stock);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStock([FromRoute] long id, Stock_Master_DTO stock)
        {
            var findId = await dbcontext.stock_master.FindAsync(id);
            if(findId!= null)
            {
                findId.Comp_Details_Id = stock.Comp_Details_Id;
                findId.Date = stock.Date;
                findId.Qty = stock.Qty;
                findId.Price = stock.Price;
                findId.Box_Unit = stock.Box_Unit;
                findId.Buyer_Name = stock.Buyer_Name;
                findId.Stock_Name = stock.Stock_Name;

                await dbcontext.SaveChangesAsync();
                return Ok(stock);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute] long id)
        {
            var findId = await dbcontext.stock_master.FindAsync(id);
            if (findId != null)
            {
                dbcontext.stock_master.Remove(findId);
                return Ok(findId);
            }
            return NotFound();
        } 
    }
}

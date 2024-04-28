using Microsoft.EntityFrameworkCore;
using SIMdevAPI.Models;

namespace SIMdevAPI.Data
{
    public class SimDataContext : DbContext
    {
        public SimDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Component_Master> comp_mast {  get; set; }
        public DbSet<Component_Details> comp_details { get; set; }
        public DbSet<Product_Master> prod_mast { get; set; }
        public DbSet<Product_Details> prod_details { get; set; }
        public DbSet<Staff_Master> staff_master { get; set; }
        public DbSet<Staff_Production_In_Entry> staff_prod_in_entry { get; set; }
        public DbSet<Spares_Out_For_Production> spares_out_for_production { get; set; }
        public DbSet<Stock_Master> stock_master { get; set; }
        public DbSet<Login_Master> login_master { get; set; }

    }
}

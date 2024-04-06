using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMdevAPI.Models
{
    public class Product_Details
    {
        [Key]
        public long Prod_Details_Id { get; set; }

        [ForeignKey("Prod_Mast_Id")]
        public long Prod_Mast_Id { get; set; }
        public Product_Master prod_master { get; set; }
        public string Prod_Name { get; set; }


        [ForeignKey("Comp_Details_Id")]
        public long Comp_Details_Id { get; set; }
        public Component_Details component_details { get; set; }
        public double Qty { get; set; }
    }
}

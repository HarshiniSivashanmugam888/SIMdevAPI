using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMdevAPI.Models
{
    public class Spares_Out_For_Production
    {
        [Key]
        public long Out_Id { get; set; }

        [ForeignKey("Staff_Id")]
        public long Staff_Id { get; set; }
        public Staff_Master staff_master { get; set; }


        [ForeignKey("Prod_Mast_Id")]
        public long Prod_Mast_Id { get; set; }
        public Product_Master product_master { get; set; }


        [ForeignKey("Comp_Details_Id")]
        public long Comp_Details_Id { get; set; }
        public Component_Details component_details { get; set; }
        public double Qty { get; set; }
        public DateTime Date { get; set; }
    }
}

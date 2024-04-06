using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMdevAPI.Models
{
    public class Stock_Master
    {
        [Key]
        public long Stock_Mast_Id { get; set; }
        [ForeignKey("Comp_Details_Id")]
        public long Comp_Details_Id { get; set; }
        public Component_Details component_details { get; set; }
        [ForeignKey("Comp_Mast_Id")]
        public long Comp_Mast_Id { get; set; }
        public Component_Master component_master { get; set; }
        public string Stock_Name { get; set; }
        public DateTime Date {  get; set; }
        public double Qty { get; set; }
        public string Box_Unit { get; set; }
        public double Price { get; set; }
        public string Buyer_Name { get; set; }

    }
}

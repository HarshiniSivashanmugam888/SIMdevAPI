using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMdevAPI.Models
{
    public class Staff_Production_In_Entry
    {
        [Key]
        public long In_Entry_Id { get; set; }

        [ForeignKey("Prod_Mast_Id")]
        public long Prod_Mast_Id { get; set; }
        public Product_Master product_master { get; set; }

        [ForeignKey("Staff_Id")]
        public long Staff_Id { get; set; }
        public Staff_Master staff_master { get; set; }
        public double Qty { get; set; }
        public DateTime Date { get; set; }
    }
}

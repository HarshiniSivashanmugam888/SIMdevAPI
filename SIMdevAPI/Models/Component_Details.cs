using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMdevAPI.Models
{
    public class Component_Details
    {
        [Key]
        public long Comp_Details_Id { get; set; }
        [ForeignKey("Comp_Mast_Id")]
        public long Comp_Mast_Id { get; set; }
        public Component_Master component_master { get; set; }
        public string Comp_Details_Name { get; set; }
        public string Unit {  get; set; }
        public string Value { get; set; }


    }
}

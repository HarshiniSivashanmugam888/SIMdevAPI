using System.ComponentModel.DataAnnotations;

namespace SIMdevAPI.Models
{
    public class Component_Master
    {
        [Key]
        public long Comp_Mast_Id { get; set; }
        public string Comp_Mast_Name { get; set; }
        public string Unit {  get; set; }
        public string Value { get; set; }
        public double Min_Qty { get; set; }
        public List<Component_Details> component_details { get; set; }

    }
}

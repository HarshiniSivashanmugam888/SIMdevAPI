using System.ComponentModel.DataAnnotations;

namespace SIMdevAPI.Models
{
    public class Product_Master
    {
        [Key]
        public long Prod_Mast_Id { get; set; }
        public string Prod_Name { get; set; }
        public List<Product_Details> product_details { get; set; }

    }
}

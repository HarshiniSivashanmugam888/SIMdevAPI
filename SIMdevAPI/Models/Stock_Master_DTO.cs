namespace SIMdevAPI.Models
{
    public class Stock_Master_DTO
    {
        public long Comp_Details_Id { get; set; }       
        public DateTime Date { get; set; }
        public string Stock_Name { get; set; }
        public double Qty { get; set; }
        public string Box_Unit { get; set; }
        public double Price { get; set; }
        public string Buyer_Name { get; set; }
    }
}

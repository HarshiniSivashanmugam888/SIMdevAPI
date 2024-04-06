namespace SIMdevAPI.Models
{
    public class Spares_Out_For_Production_DTO
    {
        public long Staff_Id { get; set; }
        public long Prod_Mast_Id { get; set; }
        public long Comp_Details_Id { get; set; }
        public double Qty { get; set; }
        public DateTime Date { get; set; }
    }
}

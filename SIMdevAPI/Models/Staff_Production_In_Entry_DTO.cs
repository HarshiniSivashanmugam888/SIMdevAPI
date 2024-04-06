namespace SIMdevAPI.Models
{
    public class Staff_Production_In_Entry_DTO
    {
        public long Prod_Mast_Id { get; set; }
        public long Staff_Id { get; set; }
        public double Qty { get; set; }
        public DateTime Date { get; set; }
    }
}

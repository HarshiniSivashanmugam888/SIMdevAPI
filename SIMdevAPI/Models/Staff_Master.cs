using System.ComponentModel.DataAnnotations;

namespace SIMdevAPI.Models
{
    public class Staff_Master
    {
        [Key]
        public long Staff_Id { get; set; }
        public string Staff_Name { get; set; }
        public string Employee_Id { get; set; }
        public string Designation { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

    }
}

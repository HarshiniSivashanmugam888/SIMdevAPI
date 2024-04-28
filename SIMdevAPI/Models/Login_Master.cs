using System.ComponentModel.DataAnnotations;

namespace SIMdevAPI.Models
{
    public class Login_Master
    {
        [Key]
        public long LoginId { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}

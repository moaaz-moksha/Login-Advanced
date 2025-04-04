using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string email {  get; set; }

        public string password { get; set; }
        
        public string confirmpassword {  get; set; }
        [Required]
        public string role { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Login.Dtos
{
    public class Logindto
    {
        [EmailAddress]
        public string email { get; set; }
        public string confirmpassword { get; set; }

        public string password { get; set; }
        [Required]
        public string role { get; set; }
    }
    public class getallusersoradmins
    {
        public string email { get; set; }
        public string password { get; set; }
      

    }
    public class Logindto0
    {
        [EmailAddress]
        public string email { get; set; }
        public string password { get; set; }
    }


}

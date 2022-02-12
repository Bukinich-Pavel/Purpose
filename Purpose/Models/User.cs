using Microsoft.AspNetCore.Identity;

namespace Purpose.Models
{
    public class User : IdentityUser
    {
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string BirthDate { get; set; }
        public string Photo { get; set; }

    }
}

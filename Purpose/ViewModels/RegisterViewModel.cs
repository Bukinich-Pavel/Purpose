using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Purpose.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        //[Remote(action: "CheckEmail", controller: "Home", ErrorMessage = "Email уже используется")]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string NickName { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string SecondName { get; set; }

        [Required]
        [Range(1, 110)]
        public int Year { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}

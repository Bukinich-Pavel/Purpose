using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Purpose.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "email address not specified")]
        //[Remote(action: "CheckEmail", controller: "Home", ErrorMessage = "Email уже используется")]
        public string Email { get; set; }

        [StringLength(20)]
        public string NickName { get; set; }

        [Required(ErrorMessage = "firstName address not specified")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "secondName address not specified")]
        [StringLength(20)]
        public string SecondName { get; set; }

        [Range(1, 110)]
        public int? Year { get; set; }

        [Required(ErrorMessage = "password address not specified")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string Password { get; set; }

        [Required(ErrorMessage = "passwordConfirm address not specified")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        public string Photo { get; set; }
    }
}

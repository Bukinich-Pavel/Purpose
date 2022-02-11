using Purpose.Models;

namespace Purpose.ViewModels
{
    public class UserFrontViewModel
    {
        public string Id { get; set;}
        public string Email { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int? Year { get; set; }
        public string PasswordHash { get; set; }
        public string Photo { get; set; }

        public UserFrontViewModel(User user)
        {
            Id = user.Id;
            Email = user.Email;
            NickName = user.NickName;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
            Year = user.Year;
            PasswordHash = user.PasswordHash;
            Photo = user.Photo;
        }
    }
}

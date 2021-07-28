namespace FruitShop.Application.ViewModels
{
    public class UserAuthenticateResponseViewModel
    {
        public UserAuthenticateResponseViewModel(UserViewModel user, string token)
        {
            user.Password = string.Empty;

            User = user;
            Token = token;
        }

        public UserViewModel User { get; set; }

        public string Token { get; set; }
    }
}

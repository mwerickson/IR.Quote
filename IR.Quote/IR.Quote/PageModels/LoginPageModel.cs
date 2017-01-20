using Acr.UserDialogs;
using FreshMvvm;
using IR.Quote.Navigation;
using PropertyChanged;
using Xamarin.Forms;

namespace IR.Quote.PageModels
{
    [ImplementPropertyChanged]
    public class LoginPageModel : FreshBasePageModel
    {
        public LoginPageModel()
        {
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public Command LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                    {
                        await UserDialogs.Instance.AlertAsync("Invalid or missing username/password",
                            "Invalid credentials", "Ok");
                        return;
                    }

                    CoreMethods.SwitchOutRootNavigation(NavigationStacks.MainAppStack);
                });
            }
        }


    }
}
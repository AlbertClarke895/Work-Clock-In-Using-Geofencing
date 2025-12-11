namespace Prototype.Views;
public partial class LoginPage : ContentPage
{

    public LoginPage()
	{
		InitializeComponent();
	}

    [Obsolete]
    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        //reads the userName entry for email
        var email = userName.Text?.Trim();
        //reads the passwordEntry entry for password
        var password = PasswordEntry.Text?.Trim();

        //checks that email and password are used in json file
        bool success = await App.UserService.LoginUser(email, password);
        if (success)
        {
            App.LoggedInEmail = email;
            await Shell.Current.GoToAsync("MainPage");
        }

        else
        {
            await DisplayAlert("Error", "Invalid email or password", "OK");
        }
    }




    //sends to the register page
    private async void RegisterBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("register");
    }

    //sends to the forgot password page
    private async void ForgotPasswordBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("password");
    }
}

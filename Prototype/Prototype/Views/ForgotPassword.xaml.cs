using Prototype.Services;

namespace Prototype.Views;

public partial class ForgotPassword : ContentPage
{
	public ForgotPassword()
	{
		InitializeComponent();
	}

    //this reads the email and password entered into the entrys
    [Obsolete]
    private async void ConfirmForgotPasswordBtn_Clicked(object sender, EventArgs e)
    {
        var email = userName.Text?.Trim();
        var newPassword = PasswordEntry.Text?.Trim();
        var confirmPassword = ConfirmPasswordEntry.Text?.Trim();


        //if any textfield is empty
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
        {
            await DisplayAlert("Error", "Please fill all fields", "OK");
            return;
        }


        //if passwords are not the same
        if (newPassword != confirmPassword)
        {
            await DisplayAlert("Error", "Passwords do not match", "OK");
            return;
        }


        //if the users email doesnt exist
        var user = App.UserService.GetUserByEmail(email);
        if (user == null)
        {
            await DisplayAlert("Error", "Email not found", "OK");
            return;
        }


        // hides the password when its stored in database and brings user back to login
        user.PasswordHash = UserDataService.HashPassword(newPassword);
        App.UserService.SaveUsersToFile();

        await DisplayAlert("Success", "Password updated", "OK");
        await Shell.Current.GoToAsync("//home");
    }
}
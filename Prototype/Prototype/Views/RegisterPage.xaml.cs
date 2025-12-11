using Prototype.Services;

namespace Prototype.Views;

public partial class RegisterPage : ContentPage
{
    private readonly UserDataService _userService = new UserDataService();

    public RegisterPage()
	{
		InitializeComponent();
	}


    // this connects the entrys
    private async void ConfirmRegisterButton_Clicked(object sender, EventArgs e)
    {
        string? email = userName.Text?.Trim();
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;
        string phone = PhoneNumber.Text;


        //checks if email is left empty
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Email and password are required.", "OK");
            return;
        }

        //checks both of the entrys are the same
        if (password != confirmPassword)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        //creates the values in the database
        bool success = await _userService.RegisterUser(email, password, phone);


        //this will display the alert showing if it was successful or not and navigate the user to the login page.
        if (success)
        {
            await DisplayAlert("Success", "User registered!", "OK");
            await Shell.Current.GoToAsync("//home"); // go to login or main page
        }
        else
        {
            await DisplayAlert("Error", "Email already registered.", "OK");
        }
    }
}
using Prototype.Services;

namespace Prototype;

public partial class App : Application
{
    public static UserDataService? UserService { get; private set; }

    public App()
    {
        InitializeComponent();

        UserService = new UserDataService(); // this shares the userdataservice across the website
        MainPage = new AppShell();

    }


    //confirms the user is logged in to display users info in profile page etc.
    public static string? LoggedInEmail { get; set; }
    public static string? CurrentGroupId { get; set; }

}

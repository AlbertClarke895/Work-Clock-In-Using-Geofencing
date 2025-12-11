namespace Prototype.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void PlusButton_Clicked(object sender, EventArgs e)
    {
        PopupOverlay.IsVisible = true;
        await PopupOverlay.FadeToAsync(1, 200);
    }

    private async void ClosePopup_Clicked(object sender, EventArgs e)
    {
        await PopupOverlay.FadeToAsync(0, 200);
        PopupOverlay.IsVisible = false;
    }

    private async void Create_Clicked(object sender, EventArgs e)
    {
        Console.WriteLine("Create selected");
        //await Shell.Current.GoToAsync("createGroup");
        ClosePopup_Clicked(sender, e);
    }

    private void Join_Clicked(object sender, EventArgs e)
    {
        Console.WriteLine("Join selected");
        ClosePopup_Clicked(sender, e);
    }

    
}

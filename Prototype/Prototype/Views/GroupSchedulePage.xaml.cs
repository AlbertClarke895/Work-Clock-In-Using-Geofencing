namespace Prototype.Views;

public partial class GroupSchedulePage : ContentPage
{
	public GroupSchedulePage()
	{
		InitializeComponent();
	}


    private async void HomeBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GroupHomePageRoute");
    }

    private async void Statistics_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GroupStatisticsPage");
    }


    private async void Schedule_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GroupSchedulePage");
    }
}
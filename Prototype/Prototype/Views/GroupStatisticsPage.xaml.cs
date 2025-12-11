namespace Prototype.Views;

public partial class GroupStatisticsPage : ContentPage
{
	public GroupStatisticsPage()
	{
		InitializeComponent();
	}



    private static async void HomeBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GroupHomePageRoute");
    }
    private static async void Statistics_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GroupStatisticsPage");
    }

    private static async void Schedule_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GroupSchedulePage");
    }
}
namespace Prototype.Views;

public partial class GroupMembers : ContentPage
{
    public List<MemberModel> Members { get; set; }
    public int MemberCount => Members?.Count ?? 0;

    public GroupMembers()
    {
        InitializeComponent();

        Members = new List<MemberModel>
        {
            new MemberModel { Name = "Steve bob" },
            new MemberModel { Name = "Sam Dean" }
        };

        BindingContext = this;
    }





    [Obsolete]
    private async void AddRole_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var member = button?.BindingContext as MemberModel;

        if (member == null)
            return;

        string role = await DisplayActionSheet(
            $"Assign role to {member.Name}",
            "Cancel", null, "Admin", "Co-Leader", "Moderator", "Member");

        if (role == "Cancel" || role == null)
            return;

        await DisplayAlert("Role Applied",
            $"{member.Name} is now a {role}.",
            "OK");

        // TODO: Save role to database
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

    private async void Roles_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GroupRolesPage");
    }

}

public class MemberModel
{
    public string Name { get; set; }
}

using Prototype.Views;

namespace Prototype
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //these allow me to navigate to these pages inside my project using the app shell
            Routing.RegisterRoute("register", typeof(RegisterPage));
            Routing.RegisterRoute("password", typeof(ForgotPassword));

            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("GroupStatisticsPage", typeof(GroupStatisticsPage));
            Routing.RegisterRoute("GroupHomePageRoute", typeof(GroupHomePage));
            Routing.RegisterRoute("GroupMembersPage", typeof(GroupMembers));
            Routing.RegisterRoute("GroupRolesPage", typeof(GroupRolesPage));
            Routing.RegisterRoute("GroupSchedulePage", typeof(GroupSchedulePage));

            //Routing.RegisterRoute("createGroup", typeof(GroupCreatePage));
            //Routing.RegisterRoute("search", typeof(MainSearch));

            //Routing.RegisterRoute("profile", typeof(MainProfile));
            //Routing.RegisterRoute("payment", typeof(PaymentInfo));
            //Routing.RegisterRoute("history", typeof(BookingHistory));

            //Routing.RegisterRoute("booking", typeof(BookingTool));

            //Routing.RegisterRoute("power", typeof(Tools.PowerTool));
            //Routing.RegisterRoute("hand", typeof(Tools.HandTool));
            //Routing.RegisterRoute("garden", typeof(Tools.GardenTool));
            //Routing.RegisterRoute("construction", typeof(Tools.ConstructionTool));

        }



    }
}
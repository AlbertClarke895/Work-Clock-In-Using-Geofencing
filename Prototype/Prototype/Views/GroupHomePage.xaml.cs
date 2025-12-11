using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using System;
using System.Threading.Tasks;

namespace Prototype.Views;

public partial class GroupHomePage : ContentPage
{
    private bool _timerRunning = false;
    private int _secondsElapsed = 0;

    public GroupHomePage()
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

    private async void Members_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GroupMembersPage");
    }

    private async void Schedule_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GroupSchedulePage");
    }

    [Obsolete]
    private void StartButton_Clicked(object sender, EventArgs e)
    {
        if (!_timerRunning)
        {
            _timerRunning = true;
            StartTimer();
            StartButton.Text = "Running...";
            StartButton.IsEnabled = false;
        }
    }

    [Obsolete]
    private void StartTimer()
    {
        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            if (_timerRunning)
            {
                _secondsElapsed++;
                TimerLabel.Text = TimeSpan.FromSeconds(_secondsElapsed).ToString(@"mm\:ss");
                return true; // keep running
            }
            return false; // stop
        });
    }

    [Obsolete]
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        //looks for last known location doesnt turn on the gps
        var location = await Geolocation.GetLastKnownLocationAsync();


        //if no location is returned requrests for location 
        if (location == null)
        {
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Location Error", "Location permission is required.", "OK");
                return;
            }

            location = await Geolocation.GetLocationAsync(new GeolocationRequest(
                GeolocationAccuracy.Low, TimeSpan.FromSeconds(3)
            ));
        }

        //sets the location in ireland if you cant get users location
        double lat = location?.Latitude ?? 54.6539;
        double lon = location?.Longitude ?? -8.1096;


        //allows me to use html also using script to use javaScript
        
        //the head loads the leaflet.js to get a interative map
        MapWebView.Source = new HtmlWebViewSource
        {
            Html = $@"
<html>
<head> 
<meta name='viewport' content='width=device-width, initial-scale=1.0'>
<link rel='stylesheet' href='https://unpkg.com/leaflet/dist/leaflet.css'/>
<script src='https://unpkg.com/leaflet/dist/leaflet.js'></script>
</head>
<body style='margin:0;padding:0;'>
<div id='map' style='width:100%; height:100%;'></div>
<script>
var userLat = {lat};
var userLon = {lon};
var map = L.map('map').setView([userLat, userLon], 12);
L.tileLayer('https://{{s}}.tile.openstreetmap.org/{{z}}/{{x}}/{{y}}.png', {{ maxZoom: 19 }}).addTo(map);
L.marker([userLat, userLon]).addTo(map);
L.circle([54.6539, -8.1096], {{ color:'green', fillColor:'#0f0', fillOpacity:0.25, radius:5000 }}).addTo(map);
</script>
</body>
</html>"
        };
    }
}
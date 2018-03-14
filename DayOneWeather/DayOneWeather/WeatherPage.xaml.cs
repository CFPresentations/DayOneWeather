using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DayOneWeather
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            Title = "Sample Weather App";
            getWeatherBtn.Clicked += GetWeatherBtn_Clicked;
            //Set the default binding to a default object for now
            BindingContext = new Weather();
        }
        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            //Weather weather = await Core.GetWeather("60601");
            //getWeatherBtn.Text = weather.Title;

            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                BindingContext = weather;
                getWeatherBtn.Text = "Search Again";
            }
        }
    }
}
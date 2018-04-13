using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //creates a collection that will be used in Button_Click()
            collection = new ObservableCollection<List1>();
            this.DataContext = this;
        }
      //when the xaml page loads this method is called 
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //gets the users location from the locationmanger cs file
                var position = await LocationManger.GetPostion();
                //goes to the class flile  OpenWeatherMapProxy() with the users latitude and longitude
                RootObject myWeather = await OpenWeatherMapProxy.GetWeather(
                    position.Coordinate.Latitude,
                    position.Coordinate.Longitude);
                //replaces the default icons with the icons in the assets/weather folder as they are named the same 
                string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
                //asigns that image to the image named Resultimage in the .xaml
                ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                //fills  TempResultTextBlock with the temp cast to an int
                //goes to myweather and get the information from openweathermapproxy then goes to the main [DataContract]
                //to get the variable temp 
                TempResultTextBlock.Text = "Temperature: " + ((int)myWeather.main.temp).ToString()+ "°C";
                DescrptionResultTextBlock.Text = "Condition: " + myWeather.weather[0].description;
                LocationResultTextBlock.Text = "Location: " + myWeather.name;
            }
            catch  
            {
                //catch is to cover if the user doesnt allow acces to locatio so there not staring at a blank screen 
                LocationResultTextBlock.Text = "Error to get Location. Please allow access to location services " ;

            }
            
        }
        //getter and setter for the collection
        public ObservableCollection<List1> collection { get; set; }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var position = await LocationManger.GetPostion();

                RootObject1 myWeatherForecast = await ForecastWeatherMapProxy.GetWeather1(position.Coordinate.Latitude,
                    position.Coordinate.Longitude);


                for (int i = 0; i < 5; i++)
                {
                    //takes the results and adds them to a list
                    collection.Add(myWeatherForecast.list[i]);
                }
                //makes the ItemsSource = to the collection in the xaml file 
                ForecastGridView.ItemsSource = collection;

            }

            catch
            {
                LocationResultTextBlock.Text = "Error to get Location. Please allow access to location services ";

            }
        }
    }
}

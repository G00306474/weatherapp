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
            collection = new ObservableCollection<List1>();
            this.DataContext = this;
        }
      
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var position = await LocationManger.GetPostion();

                RootObject myWeather = await OpenWeatherMapProxy.GetWeather(
                    position.Coordinate.Latitude,
                    position.Coordinate.Longitude);
                string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
                ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

                TempResultTextBlock.Text = "Temperature: " + ((int)myWeather.main.temp).ToString()+ "°C";
                DescrptionResultTextBlock.Text = "Condition: " + myWeather.weather[0].description;
                LocationResultTextBlock.Text = "Location: " + myWeather.name;

               
             

            }
            catch  
            {
                LocationResultTextBlock.Text = "Error to get Location. Please allow access to location services " ;

            }
            
        }
        public ObservableCollection<List1> collection { get; set; }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
                var position = await LocationManger.GetPostion();

                RootObject1 myWeatherForecast = await ForecastWeatherMapProxy.GetWeather1(position.Coordinate.Latitude,
                    position.Coordinate.Longitude);
           

            for (int i = 0; i < 5; i++)
                {
                    
                    collection.Add(myWeatherForecast.list[i]);
                }

                ForecastGridView.ItemsSource = collection;
            
          
        }
    }
}

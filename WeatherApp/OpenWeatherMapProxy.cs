using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class OpenWeatherMapProxy
    {
        public async static Task<RootObject> GetWeather(double lat, double lon)
        {
            //HttpClient() Provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI
            var http = new HttpClient();
            //calls the openweather api and passes the lon and lat variable 
            //passes the result inot url 
            
            var url = String.Format("http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units=metric&appid=5bfe62f124a556092c27cad0f9752109", lat, lon);
            // The await operator suspends GetWeather.
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            //creates a new MemoryStream with utf8 encodeing that writes result to ms
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            //passses me to the serializer and adds to var data
            var data = (RootObject)serializer.ReadObject(ms);
            return data;
        }

    }
    //Define the data contract for Coord by attaching the DataContractAttribute 
    //to the class and DataMemberAttribute attribute to the members you want to serialize
    [DataContract]
    public class Coord
    {
        [DataMember]
        public double lon { get; set; }

        [DataMember]
        public double lat { get; set; }
    }
    [DataContract]
    public class Weather
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string main { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string icon { get; set; }
    }
    [DataContract]
    public class Main
    {
        [DataMember]
        public double temp { get; set; }
        [DataMember]
        public double pressure { get; set; }
        [DataMember]
        public int humidity { get; set; }
        [DataMember]
        public double temp_min { get; set; }
        [DataMember]
        public double temp_max { get; set; }
        [DataMember]
        public double sea_level { get; set; }
        [DataMember]
        public double grnd_level { get; set; }
    }
    [DataContract]
    public class Wind
    {
        [DataMember]
        public double speed { get; set; }
        [DataMember]
        public int deg { get; set; }
    }
    [DataContract]
    public class Clouds
    {
        [DataMember]
        public int all { get; set; }
    }
    [DataContract]
    public class Sys
    {
        [DataMember]
        public double message { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public int sunrise { get; set; }
        [DataMember]
        public int sunset { get; set; }
    }
    
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public Coord coord { get; set; }
        [DataMember]
        public List<Weather> weather { get; set; }
        [DataMember]
        public string @base { get; set; }
        [DataMember]
        public Main main { get; set; }
        [DataMember]
        public Wind wind { get; set; }
        [DataMember]
        public Clouds clouds { get; set; }
        [DataMember]
        public int dt { get; set; }
        [DataMember]
        public Sys sys { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int cod { get; set; }
        //[DataMember]
        //public List<List> list { get; set; }

    }




}
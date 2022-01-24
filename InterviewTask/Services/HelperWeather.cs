using InterviewTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace InterviewTask.Services
{
    public class HelperWeather
    {
        public static List<string> WeatherList(string City)
        {
            //Assign API KEY which received from OPENWEATHERMAP.ORG  
            
            string appId = "c2da6206e772a0d8a3b62547152ab081";

            //API path with CITY parameter and other parameters.  
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0},GB&units=metric&cnt=1&APPID={1}", City, appId);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                //Converting to OBJECT from JSON string.  
                RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<RootObject>(json);

                //Special VIEWMODEL design to send only required fields not all fields which received from   
                //www.openweathermap.org api  
                ResultViewModel rslt = new ResultViewModel();

                rslt.City = weatherInfo.name;
                rslt.Description = weatherInfo.weather[0].description;
                rslt.Temp = Convert.ToString(weatherInfo.main.temp);
                rslt.TempMax = Convert.ToString(weatherInfo.main.temp_max);
                rslt.TempMin = Convert.ToString(weatherInfo.main.temp_min);

                List<string> WeatherList = new List<string>();
                WeatherList.Add(weatherInfo.name);
                WeatherList.Add(rslt.Description);
                WeatherList.Add(rslt.Temp);
                WeatherList.Add(rslt.TempMin);
                WeatherList.Add(rslt.TempMax);

                return WeatherList;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using sun_or_rain.Model;
using sun_or_rain.db;
using System.Threading.Tasks;

namespace sun_or_rain.Controller
{
    class Controller
    {
        Apixu<MainModel> process = new Apixu<MainModel>();
        //decide which apixu model to do
        //main page: list of cities (- to remove) searchbox
        //second page: results of json for the city selected and function
        public MainModel.APIXUCurrentWeather GetWeather(string city)
        {
            var details = process.GetCurrentWeather(city);
            return details;
        }
    }
}

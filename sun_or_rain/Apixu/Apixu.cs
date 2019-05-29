using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using sun_or_rain.Model;
using RestSharp;
using static sun_or_rain.Model.MainModel;


namespace sun_or_rain.Apixu
{
    class Apixu<t>
    {
        private const string API = "http://api.apixu.com/";
        private const string key = "d987ba1dd3c547fbba4140430192705";
        private const string current = "v1/current.json?key=";


        public APIXUCurrentWeather GetCurrentWeather(string city)
        {
            var apixu = new RestClient(API);
            var request = new RestRequest
            {
                Resource = current + key + "&q=" + city,
                Method = Method.GET
            };

            return JsonConvert.DeserializeObject<APIXUCurrentWeather>(apixu.Execute(request).Content);
        }

        public async Task<APIXUCurrentWeather> GetCurrentWeatherAsync(string city)
        {
            var apixu = new RestClient(API);
            var request = new RestRequest
            {
                Resource = current + key + "&q=" + city,
                Method = Method.GET
            };

            var restResponse = await apixu.ExecuteTaskAsync(request);
            return JsonConvert.DeserializeObject<APIXUCurrentWeather>(restResponse.Content);
        }

        
    }    

}

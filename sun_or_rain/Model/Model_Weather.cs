using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using sun_or_rain.Model;

namespace sun_or_rain.Model
{
    public class MainModel
    {
        public class Location
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("Region")]
            public string Region { get; set; }
            [JsonProperty("country")]
            public string Country { get; set; }
            [JsonProperty("lat")]
            public double Lat { get; set; }
            [JsonProperty("lon")]
            public double Lon { get; set; }
            [JsonProperty("tz_id")]
            public string TimeZoneID { get; set; }
            [JsonProperty("localtime_epoch")]
            public int LocalTimeEpoch { get; set; }
            [JsonProperty("localtime")]
            public string LocalTime { get; set; }
        }

        public class Condition
        {
            [JsonProperty("text")]
            public string Text { get; set; }
            [JsonProperty("icon")]
            public string Icon { get; set; }
            [JsonProperty("code")]
            public int Code { get; set; }
        }

        public class Current
        {
            
            [JsonProperty("last_updated")]
            public string LastUpdated { get; set; }
            [JsonProperty("temp_c")]
            public double TempC { get; set; }
           
            [JsonProperty("condition")]
            public Condition Condition { get; set; }
            
            [JsonProperty("wind_kph")]
            public double WindKph { get; set; }
            [JsonProperty("wind_degree")]
            public int WindDegree { get; set; }
            [JsonProperty("wind_dir")]
            public string WindDir { get; set; }
            
            [JsonProperty("precip_mm")]
            public double PrecipMm { get; set; }
            
            [JsonProperty("humidity")]
            public int Humidity { get; set; }
            [JsonProperty("cloud")]
            
            public double FeelsLikeC { get; set; }
            

        }
    }
}

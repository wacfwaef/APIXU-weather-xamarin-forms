using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using sun_or_rain.Model;
using sun_or_rain.Controller;

namespace sun_or_rain.ViewModel
{
    class VMdetails
    {
        public string chosen { get; set; }
        public VMdetails()
        {

            Controller.Controller a = new Controller.Controller();
            a.GetWeather(chosen);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private MainModel weather_model;

        public MainModel WeatherMainModel
        {
            get { return weather_model; }
            set
            {
                weather_model = value;
                OnPropertyChanged();
            }
        }
        private Favourite _cities;   // for entry binding and for method parameter value
        public Favourite cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                OnPropertyChanged();
            }
        }
    }
}

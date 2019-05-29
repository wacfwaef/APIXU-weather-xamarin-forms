using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using sun_or_rain.Model;
using sun_or_rain.Apixu;



namespace sun_or_rain.ViewModel
{
    class VM : INotifyPropertyChanged
    {
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

        private Favourite.FavCity _cities;   // for entry binding and for method parameter value
        public Favourite.FavCity cities
        {
            get { return _cities?? _cities == new Favourite.FavCity(); }
            set
            {
                if(_cities != value)
                _cities = value;
                
                OnPropertyChanged();
            }
        }

        private string _iconImageString; // for weather icon image string binding
        public string IconImageString
        {
            get { return _iconImageString; }
            set
            {
                _iconImageString = value;
                OnPropertyChanged();
            }
        }


        private bool _isBusy;   // for showing loader when the task is initializing
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }

        }
    }
}
    

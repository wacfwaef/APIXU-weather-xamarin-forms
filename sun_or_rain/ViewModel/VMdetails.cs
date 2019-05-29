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
    class VMdetails
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Favourite.FavCity _cities;   // for entry binding and for method parameter value
        public Favourite.FavCity cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                Task.Run(async () => {
                    await GetCurrentWeatherAsync(_city);
                });
                OnPropertyChanged();
            }
        }
    }
}

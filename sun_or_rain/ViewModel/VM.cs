using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using sun_or_rain.Model;
using sun_or_rain.Apixu;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;

namespace sun_or_rain.ViewModel
{
    class VM : INotifyPropertyChanged
    {
        public VM()
        {
            
            //todo database read cities here
            FavouriteC = new ObservableCollection<Favourite>
            {
                new Favourite{Cityname = "Penafiel"},
                new Favourite{Cityname = "Porto"}
            };
            
            onItemAdded = new Command(AddFavourites);
            onRemove = new Command(RemoveCity);
        //SaveOp = new Command(SaveItem);
        //DeleteOp = new Command(DeleteItem);
    }
        
        public ICommand onItemAdded { get; set; }  
        public ICommand onRemove { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public void AddFavourites()
        {
            //add input data to the database
        }

        public void RemoveCity()
        {
            //remove selected item from the database
        }
        public ObservableCollection<Favourite> FavouriteC { get; set; }
        public Command<Favourite> RemoveCommand
        {
            get
            {
                return new Command<Favourite>((cityname) =>
            {
                FavouriteC.Remove(cityname);
            });
                // for entry binding and for method parameter value
            }
        }

        


        
    }
}
    

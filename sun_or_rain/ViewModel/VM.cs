using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using sun_or_rain.Model;
using sun_or_rain.db;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using System.Linq;

namespace sun_or_rain.ViewModel
{
    class VM : INotifyPropertyChanged
    {
        ObservableCollection<Favourite> favourites;
        Favourite item;

        public VM()
        {
            OnItemAdded = new Command(AddFavourite);
            OnRemove = new Command(RemoveFavourite);
            OnNewCity = new Command(Search);
        }

        public ICommand OnItemAdded { get; set; }  
        public ICommand OnRemove { get; set; }
        public ICommand OnNewCity { get; set; }
        public INavigation Nav { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Favourite Item
        {
            set { SetProperty(ref item, value); }
            get { return item; }
        }

        async void AddFavourite()
        {
            if (Item != null)
            {
                if (Item.ID != null)
                {
                    int p = FavouritesVar.IndexOf(Item);
                    FavouritesVar.Remove(Item);
                    FavouritesVar.Insert(p, Item);
                }
                else
                    FavouritesVar.Add(Item);
                await App.Database.SaveItemAsync(Item);
                await Nav.PopAsync();
            }
        }

        async void RemoveFavourite()
        {
            if (Item != null)
            {
                FavouritesVar.Remove(Item);
                await App.Database.DeleteItemAsync(Item);
                await Nav.PopAsync();
            }
        }

        async void Search()
        {
            Item = FavouritesVar.Last();
        }


        public ObservableCollection<Favourite> FavouritesVar
        {
            set { SetProperty(ref favourites, value); }
            get
            {
                if (favourites == null)
                    Initialize();
                return favourites;
            }
        }

        private async void Initialize()
        {
            List<Favourite> list = await App.Database.GetItemsAsync();
            FavouritesVar = new ObservableCollection<Favourite>(list);
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
    

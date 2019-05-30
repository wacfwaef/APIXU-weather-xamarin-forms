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
using System.Linq;

namespace sun_or_rain.ViewModel
{
    class VM : INotifyPropertyChanged
    {
        ObservableCollection<Favourite> FavouritesVar;
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
                await MainPage.Database.SaveItemAsync(Item);
                await Nav.PopAsync();
            }
        }

        async void RemoveFavourite()
        {
            if (Item != null)
            {
                FavouritesVar.Remove(Item);
                await MainPage.Database.DeleteItemAsync(Item);
                await Nav.PopAsync();
            }
        }

        async void Search()
        {
            Item = FavouritesVar.Last();
        }


        public ObservableCollection<Favourite> Favourites
        {
            set { SetProperty(ref FavouritesVar, value); }
            get
            {
                if (FavouritesVar == null)
                    Initialize();
                return FavouritesVar;
            }
        }

        private async void Initialize()
        {
            List<Favourite> list = await MainPage.Database.GetItemsAsync();
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
    

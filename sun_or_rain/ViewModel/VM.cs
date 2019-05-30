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
using sun_or_rain.View;
using sun_or_rain.Controller;

namespace sun_or_rain.ViewModel
{
    class VM : VM_base
    {
        ObservableCollection<Favourite> favourites;
        Favourite item = new Favourite();

        public VM()
        {
            OnItemAdded = new Command(AddFavourite);
            OnRemove = new Command((e) => {RemoveFavourite((e as Favourite));});
            OnNewCity = new Command(ViewNewCity);

        }

        public ICommand OnItemAdded { get; set; }  
        public ICommand OnRemove { get; set; }
        public ICommand OnNewCity { get; set; }
        public INavigation Nav { get; set; }
        
        
        public Favourite Item
        {
            set { SetProperty(ref item, value); }
            get { return item; }
        }
        //MAIN VIEW
        async void AddFavourite()
        {
            if (Item.Cityname != null && Item.Cityname != "")
            {
                Search();
                if (Item.ID != 0)
                {
                    int p = FavouritesVar.IndexOf(Item);
                    FavouritesVar.Remove(Item);
                    FavouritesVar.Insert(p, Item);
                }
                else
                    FavouritesVar.Add(Item);
                await App.Database.SaveItemAsync(Item);
                Item = new Favourite();
            }
        }
        
        async void RemoveFavourite(Favourite item)
        {
            if (item != null && item.ID != 0)
            {
                FavouritesVar.Remove(item);
                await App.Database.DeleteItemAsync(item);
            }
        }

        void Search()
        {
            foreach(Favourite itemLoop in FavouritesVar) 
            {
                if (Item.Cityname == itemLoop.Cityname)
                {
                    Item = itemLoop;
                    return;
                }
            }
            Item.ID = 0;
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
        async void ViewNewCity()
        {

            if (Item.Cityname != null)
            {
                await Nav.PushAsync(new NavigationPage(new View_Weather
                {
                    BindingContext = new VMdetails(item.Cityname)
                    {
                    }
                }));
            }

        }
        private async void Initialize()
        {
            List<Favourite> list = await App.Database.GetItemsAsync();
            FavouritesVar = new ObservableCollection<Favourite>(list);
        }

        //VIEW WEATHER
    }
}
    

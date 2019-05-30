using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using sun_or_rain.Model;
using System.Data.SQLite;
using sun_or_rain.ViewModel;
using sun_or_rain.View;
using sun_or_rain.Apixu;

namespace sun_or_rain
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static FavouritesDatabase database;
        public MainPage()
        {
            ListView citieslist = new ListView
            {

            };
            BindingContext = new VM();
            InitializeComponent();
        }

        public static FavouritesDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new FavouritesDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("FavouritesSQLite.db3"));
                }
                return database;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public void ViewNewCity()
        {
            Entry entry = new Entry();
            if (entry.Text != null)
            {
                //new page with input
            }

        }

        protected override void OnDisappearing()
        {
            //if(ListView.)
        }

        
        
        
        async void onItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new View_Weather
                {
                    BindingContext = new VMdetails
                    {
                        //new page with selected
                    }
                }) ;
            }
        }
    }
}

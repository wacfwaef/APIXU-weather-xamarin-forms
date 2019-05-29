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

namespace sun_or_rain
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            ListView citieslist = new ListView
            {

            };
            BindingContext = new VM();
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection())
            {
                //connection database to appear the cities;
            }
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

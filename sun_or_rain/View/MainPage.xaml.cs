﻿using System;
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
using sun_or_rain.db;

namespace sun_or_rain
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new VM();
            InitializeComponent();
        }

        

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        

        protected override void OnDisappearing()
        {
            //if(ListView.)
        }

        async void onItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var item = ((Favourite)e.SelectedItem).Copy();
                await Navigation.PushAsync(new NavigationPage(new View_Weather
                {
                    BindingContext = new VMdetails(item.Cityname)
                    {
                        //new page with selected
                    }
                })) ;
            }
        }

        async void onInputSelected(object sender, EventArgs e)
        {
            if (input.Text != null)
            {
                
                await Navigation.PushAsync(new NavigationPage(new View_Weather
                {
                    BindingContext = new VMdetails(input.Text)
                    {
                        //new page with selected
                    }
                }));
            }
        }
    }
}

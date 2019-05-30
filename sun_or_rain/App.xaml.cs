using sun_or_rain.db;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sun_or_rain
{
    public partial class App : Application
    {
        public static FavouritesDatabase database;
        public App()
        {
            

        var nav = new NavigationPage(new MainPage());
        
        nav.BarTextColor = Color.Black;

            MainPage = nav;
            
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
    protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

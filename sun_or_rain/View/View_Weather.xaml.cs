using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sun_or_rain.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_Weather : ContentPage
    {
        public View_Weather()
        {
            InitializeComponent();
        }
        async void NavigateBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
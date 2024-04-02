using AndroidAppMyCities.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AndroidAppMyCities.Views
{
    public partial class CitiesListlPage : ContentPage
    {
        public CitiesListlPage()
        {
            InitializeComponent();
            BindingContext = new CityViewModel();
        }
    }
}
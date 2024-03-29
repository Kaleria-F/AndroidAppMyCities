using AndroidAppMyCities.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AndroidAppMyCities.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new CityViewModel();
        }
    }
}
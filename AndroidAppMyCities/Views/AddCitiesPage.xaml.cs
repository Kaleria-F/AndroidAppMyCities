using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppMyCities.Models;
using AndroidAppMyCities.Services;
using AndroidAppMyCities.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace AndroidAppMyCities.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCitiesPage : ContentPage

    {
        public List<string> citiesList;

        public AddCitiesPage()
        {
            InitializeComponent();

            CityDatabase database = CityDatabase.Instance;
            citiesList = database.GetCitiesNames();
            CityList.ItemsSource = citiesList;

            CityList.ItemTapped += CityList_ItemTapped;
        }
        private void CitySearch_SearchButtonPressed(object sender, EventArgs e)
        {
            string key = CitySearch.Text;

            if (string.IsNullOrEmpty(key))
            {
                CitySearch.Placeholder = "Введите название города";
                return;
            }

            IEnumerable<string> searchResult = citiesList.Where(name => name.ToLower().Contains(key.ToLower()));

            CityList.ItemsSource = searchResult;
        }
        private void CityList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedCity = e.Item as string;

            Navigation.PushAsync(new NewItemPage(selectedCity));
        }
    }
}

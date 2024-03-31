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
            //инициализация компонентов страницы AddCitiesPage
            InitializeComponent();

            CityDatabase database = CityDatabase.Instance; //создание экземпляра класса CityDatabase - базы данных городов
            citiesList = database.GetCitiesNames(); //получение списка названий городов из базы данных
            CityList.ItemsSource = citiesList; //привязка списка городов к элементу CityList

            CityList.ItemTapped += CityList_ItemTapped;
        }


        private void CitySearch_SearchButtonPressed(object sender, EventArgs e)
        {
            string key = CitySearch.Text; //получение текста из элемента CitySearch


            if (string.IsNullOrEmpty(key))
            {
                //выводить в строку поиска "Введите название города"
                CitySearch.Placeholder = "Введите название города";
                return;
            }

            IEnumerable<string> searchResult = citiesList.Where(name => name.ToLower().Contains(key.ToLower())); //поиск городов по ключу

            CityList.ItemsSource = searchResult; //привязка результата поиска к элементу CityList
        }

        private void CityList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Получение выбранного города
            var selectedCity = e.Item as string;

            // Переход на новую страницу
            Navigation.PushAsync(new NewItemPage(selectedCity));
        }
    }
}

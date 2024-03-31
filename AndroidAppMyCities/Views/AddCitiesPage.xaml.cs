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
       // List<string> citiList = new List<string> { "Moscow", "London", "Paris", "Berlin", "Madrid", "Rome", "Prague", "Vienna", "Amsterdam", "Warsaw", "Budapest", "Stockholm", "Oslo", "Copenhagen", "Helsinki", "Dublin", "Lisbon", "Athens", "Brussels", "Luxembourg", "Bern", "Monaco", "Andorra la Vella", "San Marino", "Vatican City" };
 
        public AddCitiesPage()
        {
            //инициализация компонентов страницы AddCitiesPage
            InitializeComponent();
            
            CityDatabase database = CityDatabase.Instance; //создание экземпляра класса CityDatabase - базы данных городов
            citiesList = database.GetCitiesNames(); //получение списка названий городов из базы данных

         
            
            //CityList.ItemsSource = citiList; //привязка списка городов к элементу CityList
            CityList.ItemsSource = citiesList; //привязка списка городов к элементу CityList
        }


        private void CitySearch_SearchButtonPressed(object sender, EventArgs e)
        {
            string key = CitySearch.Text; //получение текста из элемента CitySearch
            //проверять на пустоту
            
            if (string.IsNullOrEmpty(key))
            {
                //выводить в строку поиска "Введите название города"
                CitySearch.Placeholder = "Введите название города";
                return;
            }

            IEnumerable<string> searchResult= citiesList.Where(name => name.ToLower().Contains(key.ToLower())); //поиск городов по ключу

            //IEnumerable<string> searchRes = citiList.Where(name => name.ToLower().Contains(key.ToLower())); //поиск городов по ключу

            CityList.ItemsSource = searchResult; //привязка результата поиска к элементу CityList
        }
    }
}

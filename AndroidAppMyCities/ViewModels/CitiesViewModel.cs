using AndroidAppMyCities.Models;
using AndroidAppMyCities.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndroidAppMyCities.ViewModels
{
    /// <summary>
    /// Класс CitiesViewModel для отображения списка городов.
    /// </summary>
    public class CitiesViewModel : BaseViewModel
    {
        private City _selectedItem;
        private int countCities;

        //метод для получения количества городов
        public int GetCountCities()
        {
            return countCities;
        }

        public ObservableCollection<City> Cities { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<City> ItemTapped { get; }

        /// <summary>
        /// Конструктор класса CitiesViewModel.
        /// </summary>
        public CitiesViewModel()
        {
            Title = "Города";
            Cities = new ObservableCollection<City>();
            countCities = Cities.Count;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //ItemTapped = new Command<City>(OnItemSelected); //метод добавлен для дальнейшей модернизации программы

            AddItemCommand = new Command(OnAddItem); 
        }

        /// <summary>
        /// Метод ExecuteLoadItemsCommand для загрузки списка городов.
        /// </summary>
        /// <returns></returns>
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Cities.Clear();
                var cities = await DataStore.GetICity(true);
                foreach (var city in cities)
                {
                    Cities.Add(city);
                    countCities++;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Метод OnAppearing для отображения списка городов.
        /// </summary>
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public City SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(City city)
        {
            if (city == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(CitiesListlPage)}?{nameof(CityViewModel.CityId)}={city.Id}");
        }
    }
}
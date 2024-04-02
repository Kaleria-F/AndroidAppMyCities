using AndroidAppMyCities.Models;
using AndroidAppMyCities.Services;
using AndroidAppMyCities.ViewModels;
using AndroidAppMyCities.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidAppMyCities.Views
{
    /// <summary>
    /// Класс CitiesDescriptionPage, представляющий страницу с описанием городов и их характеристик.
    /// </summary>
    public partial class CitiesDescriptionPage : ContentPage
    {
        /// <summary>
        /// Экземпляр класса CitiesViewModel для обновления данных.
        /// </summary>
        CitiesViewModel _viewModel;

        /// <summary>
        /// Конструктор класса CitiesDescriptionPage.
        /// </summary>
        public CitiesDescriptionPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CitiesViewModel();
        }

        /// <summary>
        /// Метод OnAppearing, вызываемый при отображении страницы для обновления данных.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();  
            _viewModel.OnAppearing();
        }

        /// <summary>
        /// Метод Button_Clicked, вызываемый при нажатии на кнопку "Добавить" со станицы уже добавленных городов.
        /// </summary>
        /// <param name="sender"> Объект, который вызывает событие. </param>
        /// <param name="e"> Параметры события. </param>
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCitiesPage());
        }
    }
}
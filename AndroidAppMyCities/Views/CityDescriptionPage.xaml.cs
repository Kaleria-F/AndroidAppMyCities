using AndroidAppMyCities.Models;
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
    public partial class CitiesDescriptionPage : ContentPage
    {
        CitiesViewModel _viewModel;

        //конструктор класса CitiesDescriptionPage для инициализации компонентов
        public CitiesDescriptionPage()
        {
            InitializeComponent();

            //привязка контекста данных к экземпляру класса CitiesViewModel для обновления данных
            BindingContext = _viewModel = new CitiesViewModel();
        }

        //переопределение метода OnAppearing для обновления данных при появлении страницы
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
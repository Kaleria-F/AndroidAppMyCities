using AndroidAppMyCities.Models;
using AndroidAppMyCities.Services;
using AndroidAppMyCities.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidAppMyCities.Views
{
    /// <summary>
    /// Метод AboutPage, отвечающий за отображение страницы "О приложении".
    /// </summary>
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent(); //инициализация компонентов страницы AboutPage
        }

        /// <summary>
        /// Метод Button_Clicked, вызываемый при нажатии на кнопку "Добавить город".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCitiesPage());
        }

        /// <summary>
        /// Метод OnAppearing, вызываемый при отображении страницы для обновления данных.
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CounterModel counter = new CounterModel();
            int courn = counter.GetCount();

            int t = courn / 1000;
            int s = (courn - t * 1000) / 100;
            int d = (courn - t * 1000 - s * 100) / 10;
            int e1 = courn - t * 1000 - s * 100 - d * 10;

            thousand.Text = t.ToString();
            hundred.Text = s.ToString();
            dozen.Text = d.ToString();
            units.Text = e1.ToString();

            await ProgressCountryBar.ProgressTo(courn / 1000.0, 900, Easing.Linear);
        }

        private void Button_Set(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetPage());
        }
        
    }
}
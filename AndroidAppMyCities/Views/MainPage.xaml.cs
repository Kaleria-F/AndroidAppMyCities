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
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent(); //инициализация компонентов страницы AboutPage
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCitiesPage()); //переход на страницу AddCityPage
        }

        private void Button_Clicked2(object sender, EventArgs e)
        {
            int count = DependencyService.Get<MockDataStore>().GetCountCity();
            //определить тысячи сотни десятки и единицы в числе городов
            int t1 = count / 1000;
            int s2 = (count - t1 * 1000) / 100;
            int d3 = (count - t1 * 1000 - s2 * 100) / 10;
            int e4 = count - t1 * 1000 - s2 * 100 - d3 * 10;
            //вывод количества городов на страницу
            thousand.Text = t1.ToString();
            hundred.Text = s2.ToString();
            dozen.Text = d3.ToString();
            units.Text = e4.ToString();
        }
        
    }
}
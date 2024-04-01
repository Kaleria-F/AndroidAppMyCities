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
            //создание экземпляра класса Counter 

            CounterModel counter = new CounterModel();
            //выгрущить кол-во городов из списка MockDataStore
            int courn = counter.GetCount();

            ///подсчет и вывод чисел тысяч сотен десятков и единиц
            int t = courn / 1000;
            int s = (courn - t * 1000) / 100;
            int d = (courn - t * 1000 - s * 100) / 10;
            int e1 = courn - t * 1000 - s * 100 - d * 10;

            thousand.Text = t.ToString();
            hundred.Text = s.ToString();
            dozen.Text = d.ToString();
            units.Text = e1.ToString();

        }
        
    }
}
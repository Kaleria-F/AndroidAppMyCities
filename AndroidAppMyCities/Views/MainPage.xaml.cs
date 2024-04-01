using AndroidAppMyCities.Models;
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

            //CityDatabase database = CityDatabase.Instance; //создание экземпляра класса CityDatabase - базы данных городов


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCitiesPage()); //переход на страницу AddCityPage
        }





    }
}
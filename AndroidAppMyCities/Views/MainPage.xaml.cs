using System;
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

            //подгрузить базу данных

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCitiesPage()); //переход на страницу AddCityPage
        }





    }
}
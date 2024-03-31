using AndroidAppMyCities.Services;
using AndroidAppMyCities.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidAppMyCities
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //var db = CityDatabase.GetInstance("cities.db");
            //var cities = db.LoadCities();

            DependencyService.Register<MockDataStore>();
            MainPage = new Menu();

        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {

        }

    }
}

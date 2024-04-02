using AndroidAppMyCities.Models;
using AndroidAppMyCities.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidAppMyCities.Views
{
    public partial class NewItemPage : ContentPage
    {
        public City YourCity { get; set; } 

        public NewItemPage(string city)
        {
            InitializeComponent();

            cityName.Text = city.ToString(); //передача названия города в текстовое поле 



            //создание экземпляра класса City и передача в конструктор названия города
            YourCity = new City
            {
                Name = city,
                
            };

            BindingContext = new NewICityViewModel(city.ToString()); //для обновления данных на странице
        }
    }
}
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
        public City yourCity { get; set; } 

        public NewItemPage(string city)
        {
            InitializeComponent();

            cityName.Text = city.ToString();


            //создание экземпляра класса City и передача в конструктор названия города
            yourCity = new City
            {
                Name = city
                //передать название города в строку Текст

            };

            BindingContext = new NewICityViewModel(); //для обновления данных на странице
        }
    }
}
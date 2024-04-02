using AndroidAppMyCities.ViewModels;
using AndroidAppMyCities.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AndroidAppMyCities
{
    /// <summary>
    /// Класс Menu для создания главного меню приложения внизу страниц.
    /// </summary>
    public partial class Menu : Xamarin.Forms.Shell
    {
        public Menu()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CitiesListlPage), typeof(CitiesListlPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            //предусмотрена возможность регистрации маршрута для страницы регистрации пользователя для будущей модернизации приложения
            //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            //<ShellContent Title="Регистрация" Icon="icon_cities_list.png" ContentTemplate="{DataTemplate local:LoginPage}"/>

        }

    }
}

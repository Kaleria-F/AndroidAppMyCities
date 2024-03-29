using AndroidAppMyCities.ViewModels;
using AndroidAppMyCities.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AndroidAppMyCities
{
    //класс AppShell для создания главного меню приложения
    public partial class Menu : Xamarin.Forms.Shell
    {
        public Menu()
        {
            //инициализация компонентов
            InitializeComponent();
            //регистрация маршрутов
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}

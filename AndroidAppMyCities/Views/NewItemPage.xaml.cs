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
        public City Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewICityViewModel();
        }
    }
}
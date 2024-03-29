using AndroidAppMyCities.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AndroidAppMyCities.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
           // префиксация с `//` переключает на другой стек навигации вместо того, чтобы добавлять к активному
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}

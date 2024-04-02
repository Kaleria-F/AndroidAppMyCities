using AndroidAppMyCities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidAppMyCities.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        //код для кнопки 
        /*<StackLayout Padding="10,0,10,0" VerticalOptions="Center">
            <Button VerticalOptions="Center" Text="Зарегистрироваться" Command="{Binding LoginCommand}"/>
        </StackLayout>*/
    }
}
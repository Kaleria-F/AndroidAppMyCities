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
	public partial class SetPage : ContentPage
	{
		public SetPage ()
		{
			InitializeComponent ();
		}

		private void OnInstructionClicked(object sender, EventArgs e)
		{
            Navigation.PushAsync(new InfoPage());
        }

		private void OnCityListDownloadClicked(object sender, EventArgs e)
		{
            

        }

		private void OnRegistrationClicked(object sender, EventArgs e)
		{
            Navigation.PushAsync(new LoginPage());
        }

		private void FeedbackClicked(object sender, EventArgs e)
		{
            Navigation.PushAsync(new FeedbackPage());
        }
	}
}
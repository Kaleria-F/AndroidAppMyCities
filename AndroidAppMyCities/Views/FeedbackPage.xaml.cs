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
	public partial class FeedbackPage : ContentPage
	{
		public FeedbackPage ()
		{
			InitializeComponent ();
		}

		private void OnWebsiteClicked(object sender, EventArgs e)
		{
            Device.OpenUri(new Uri("https://t.me/Kaleria_f"));

        }
	}
}
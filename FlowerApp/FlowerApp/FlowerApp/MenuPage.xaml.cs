using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlowerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
		}

        async void OnBtnFlowerTypeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListFlowerTypesPage());
        }

        async void OnBtnFlowerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListFlowersPage());
        }
    }
}
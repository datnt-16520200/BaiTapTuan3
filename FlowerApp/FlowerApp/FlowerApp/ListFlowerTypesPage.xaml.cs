using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlowerApp.Models;

namespace FlowerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListFlowerTypesPage : ContentPage
	{
		public ListFlowerTypesPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetFlowerTypesAsync();
        }

        async void OnFlowerTypeAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FlowerTypeEntryPage
            {
                BindingContext = new FlowerType()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new FlowerTypeEntryPage
                {
                    BindingContext = e.SelectedItem as FlowerType
                });
            }
        }
    }
}
﻿using System;
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
	public partial class ListFlowersPage : ContentPage
	{
		public ListFlowersPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetFlowersAsync();
        }

        async void OnFlowerAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FlowerEntryPage
            {
                BindingContext = new Flower()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new FlowerEntryPage
                {
                    BindingContext = e.SelectedItem as Flower
                });
            }
        }
    }
}
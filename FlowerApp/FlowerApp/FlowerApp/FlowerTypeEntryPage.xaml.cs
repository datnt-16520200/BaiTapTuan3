using System;
using System.IO;
using Xamarin.Forms;
using FlowerApp.Models;

namespace FlowerApp
{
	public partial class FlowerTypeEntryPage : ContentPage
	{
		public FlowerTypeEntryPage ()
		{
			InitializeComponent ();
		}

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var flowerType = (FlowerType)BindingContext;
            
            if (flowerType.typeName == null || (flowerType.typeName.Trim()).Length == 0)
            {
                DisplayAlert("Error", "Bạn chưa nhập tên loại hoa", "OK");
            }
            else 
            {
                flowerType.typeName = flowerType.typeName.Trim();
                await App.Database.SaveFlowerTypeAsync(flowerType);
                await Navigation.PopAsync();
            }
            
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var flowerType = (FlowerType)BindingContext;
            await App.Database.DeleteFlowerTypeAsync(flowerType);
            await Navigation.PopAsync();
        }
    }
}
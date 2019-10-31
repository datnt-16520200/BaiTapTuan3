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
	public partial class FlowerEntryPage : ContentPage
	{
        List<FlowerType> dataFlowerType;

        public FlowerEntryPage ()
		{
			InitializeComponent ();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var pickerList = new List<String>();
            dataFlowerType = await App.Database.GetFlowerTypesAsync();

            dataFlowerType.ForEach(i => pickerList.Add(i.typeName));

            pickerFlowerType.ItemsSource = pickerList;

            var flower = (Flower)BindingContext;

            if (flower.ID == 0)
            {
                pickerFlowerType.SelectedIndex = 0;
            }
            else
            {
                txtFlowerName.Text = flower.flowerName;
                txtImage.Text = flower.image;
                txtPrice.Text = flower.price + "";
                txtDescription.Text = flower.description;

                var indexPicker = -1;
                foreach (var i in dataFlowerType)
                {
                    indexPicker += 1;
                    if (i.ID == flower.flowerType)
                    {
                        break;
                    }
                }

                pickerFlowerType.SelectedIndex = indexPicker;
            }

            //xiu tinh tiep
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var flower = (Flower)BindingContext;

            var flowertype = (String) pickerFlowerType.SelectedItem;
            var flowerName = txtFlowerName.Text;
            var image = txtImage.Text;
            var price = txtPrice.Text;
            var description = txtDescription.Text;

            if (flowertype != null && flowerName != null && image != null && price != null
                && description != null)
            {
                if (flowertype.Trim().Length != 0 && flowerName.Trim().Length != 0
                    && image.Trim().Length != 0 && price.Trim().Length != 0 
                    && description.Trim().Length != 0)
                {
                    var iFlowerType = 0;
                    foreach (var i in dataFlowerType)
                    {
                        if (i.typeName.Trim().Equals(flowertype.Trim()))
                        {
                            iFlowerType = i.ID;
                            break;
                        }
                    }

                    flower.flowerType = iFlowerType;
                    flower.flowerName = flowerName;
                    flower.image = image;
                    flower.price = double.Parse(price.Trim());
                    flower.description = description;

                    await App.Database.SaveFlowerAsync(flower);
                    await Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Error", "Có một vài trường chỉ có ký tự trắng", "OK");
                }
                
            }
            else
            {
                DisplayAlert("Error", "Bạn nhập chưa đầy đủ các trường", "OK");
            }
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var flower = (Flower)BindingContext;
            await App.Database.DeleteFlowerAsync(flower);
            await Navigation.PopAsync();
        }
    }
}
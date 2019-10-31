using System;
using System.IO;
using Xamarin.Forms;
using FlowerApp.Data;

namespace FlowerApp
{
    public partial class App : Application
    {
        static FlowerDatabase database;
        public static FlowerDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new FlowerDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Flowers.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new MenuPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

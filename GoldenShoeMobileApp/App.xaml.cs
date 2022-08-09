using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenShoeMobileApp
{
    public partial class App : Application
    {
        /// <summary>
        /// Application constructor
        /// </summary>
        public App()
        {
            // Initialise the component
            InitializeComponent();

            // Set the main page to a new instance of the app shell
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Invoke the populate shoe list function to populate the global shoe list
            AppData.PopulateShoeList();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
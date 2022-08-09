using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenShoeMobileApp.Views;
using Xamarin.Forms;

namespace GoldenShoeMobileApp
{
    public partial class AppShell : Shell
    {
        // --- App Shell Variable --- //
        #region App Shell Variable
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>(); // Routes dictionary
        #endregion App Shell Variables

        // --- App Shell Constructor --- //
        #region App Shell Constructor
        /// <summary>
        /// Constructor for the App Shell partial class
        /// </summary>
        public AppShell()
        {
            // Initialise the component
            InitializeComponent();

            // Invoke the register routes function page navigation with the shell
            RegisterRoutes();
        }
        #endregion App Shell Constructor

        // --- App Shell Method --- //
        #region App Shell Method
        /// <summary>
        /// Method is used to register routes to allow the shell
        /// to navigate through the application
        /// </summary>
        private void RegisterRoutes()
        {
            // Add the Shoes page to the routes dictionary
            Routes.Add(nameof(ShoePage), typeof(ShoePage));

            // Add the Shoe Details page to the routes dictionary
            Routes.Add(nameof(ShoeDetails), typeof(ShoeDetails));

            // Iterate over all items
            foreach(var item in Routes)
            {
                // Register the item key and item value as a pair for the shell navigation route
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
        #endregion App Shell Method
    }
}
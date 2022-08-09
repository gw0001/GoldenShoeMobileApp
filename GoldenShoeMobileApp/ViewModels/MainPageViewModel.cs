using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using GoldenShoeMobileApp.Models;

namespace GoldenShoeMobileApp.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        // --- Main Page View Model Variables --- //
        #region Main Page View Model Variables

        private List<ShoeModel> _featuredShoes; // Shoe list for the main page
        private ShoeModel _selectedShoe; // Selected Shoe

        #endregion Main Page View Model Variables
        
        // --- Main Page View Model Constructor --- //
        #region Main Page View Model Constructor
        /// <summary>
        /// When invoked, a shoes view model instance is
        /// created and the Get Shoes function is invoked
        /// </summary>
        public MainPageViewModel()
        {
            _featuredShoes = GetFeaturedShoes();
        }

        #endregion Shoes View Model Constructor

        /// <summary>
        /// Method is used to set and return the value held by
        /// the shoes variable. When value is set, the 
        /// On Property Changed method is invoked
        /// </summary>
        public List<ShoeModel> FeaturedShoes
        {
            get
            {
                return _featuredShoes;
            }
            set
            {
                _featuredShoes = value;

                OnPropertyChanged();
            }
        }

        

        /// <summary>
        /// Method is used to set and return the value held by
        /// the selected shoe variable. When value is set, the 
        /// On Property Changed method is invoked
        /// </summary>
        public ShoeModel SelectedShoe
        {
            get
            {
                return _selectedShoe;
            }
            set
            {
                _selectedShoe = value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Method obtains a list of featured shoes. In this case,
        /// these are shoes that are not out of stock
        /// </summary>
        private List<ShoeModel> GetFeaturedShoes()
        {
            // Check if the App Data List is empty
            if (AppData.ShoeList.Count == 0)
            {
                AppData.PopulateShoeList();
            }

            // Create a new empty featured list of shoes
            List<ShoeModel> featuredShoes = new List<ShoeModel>();

            // Iterate over all shoes in the master shoe list
            foreach (ShoeModel shoe in AppData.ShoeList)
            {
                // Check if the shoe quantity is greater than 0 (in stock)
                if (shoe.Quantity > 0)
                {
                    // Add the shoe to the list
                    featuredShoes.Add(shoe);
                }
            }

            // Return the list of featured shoes
            return featuredShoes;
        }

        /// <summary>
        /// Selection command creates a new command which
        /// activates the View Shoe Details function.
        /// </summary>
        public ICommand SelectionCommand => new Command(ViewShoeDetails);

        /// <summary>
        /// Function first checks that the selected show
        /// is not null. If this is the case,
        /// the Go To Details Page from the super class
        /// is invoked. Once invoked, the method waits for
        /// it to complete its function.
        /// </summary>
        private async void ViewShoeDetails()
        {
            if (SelectedShoe != null)
            {
                await GoToDetailsPage(SelectedShoe);
            }
        }
    }
}
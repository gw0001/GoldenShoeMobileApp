using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using GoldenShoeMobileApp.Models;
using GoldenShoeMobileApp.Views;

namespace GoldenShoeMobileApp.ViewModels
{
    public class ShoesViewModel : BaseViewModel
    {
        // --- Shoes View Model Variables --- //
        #region Shoes View Model Variables

        private List<ShoeModel> _shoes; // Observable collection of shoes
        private ShoeModel _selectedShoe; // Selected Shoe
        private bool _listInitialised = false; // Is initialised set to false

        #endregion Shoes View Model Variables

        // --- Shoes View Model Constructor --- //
        #region Shoes View Model Constructor
        /// <summary>
        /// When invoked, a shoes view model instance is
        /// created and the Get Shoes function is invoked
        /// </summary>
        public ShoesViewModel()
        {
            // Check if list is initialised
            if(!_listInitialised)
            {
                // Obtain the shoes from the shoe list
                _shoes = GetShoeList();

                // Set list initialised to true
                _listInitialised = true;
            }
        }

        #endregion Shoes View Model Constructor

        /// <summary>
        /// Method is used to set and return the value held by
        /// the shoes variable. When value is set, the 
        /// On Property Changed method is invoked
        /// </summary>
        public List<ShoeModel> Shoes
        {
            get
            {
                return _shoes;
            }
            set
            {
                _shoes = value;
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
        /// Temporary method for creating mock data
        /// </summary>
        /// <returns></returns>
        private List<ShoeModel> GetShoeList()
        {
            // Check if the App Data List is empty
            if (AppData.ShoeList.Count == 0)
            {
                AppData.PopulateShoeList();
            }

            // Create a new empty featured list of shoes
            List<ShoeModel> shoeList = new List<ShoeModel>();

            foreach (ShoeModel shoe in AppData.ShoeList)
            {
                shoeList.Add(shoe);
            }


            // Return the list of featured shoes
            return shoeList;
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
            if(SelectedShoe != null)
            {
                await GoToDetailsPage(SelectedShoe);
            }
        }
    }
}
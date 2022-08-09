using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using GoldenShoeMobileApp.Models;

namespace GoldenShoeMobileApp.ViewModels
{
    public class ShoeDetailsViewModel : BaseViewModel
    {
        // --- Shoe Details View Model Variables --- //
        #region Shoe Details View Model Variables
        private ShoeModel _selectedShoe; // Selected Shoe
        #endregion Shoe Details View Model Variables

        /// <summary>
        /// Method is used to return the value held by the
        /// selected shoe variable, or to set the value of this
        /// variable and invoke the On Property Changed method
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

                // Invoke the On Property Changed method
                OnPropertyChanged();
            }
        }

    }
}
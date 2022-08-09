// Directives
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GoldenShoeMobileApp.Models;
using GoldenShoeMobileApp.Views;
using Xamarin.Forms;

namespace GoldenShoeMobileApp.ViewModels
{
    // Might need to change this for a method within each viewmodel class... wait and see
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Public Propertu Changed event handler
        public event PropertyChangedEventHandler PropertyChanged;
    
        /// <summary>
        /// Method used when a property has been changed
        /// </summary>
        public void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        /// <summary>
        /// Method first sets a global variable to hold
        /// the details of the user selected shoe. Next,
        /// the method invokes and waits for the application
        /// shell to find the location of the shoe details page
        /// and load it to screen.
        /// </summary>
        public static async Task GoToDetailsPage(ShoeModel aShoe)
        {
            AppData.DisplayDetails = aShoe;
            await Shell.Current.GoToAsync($"{nameof(ShoeDetails)}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenShoeMobileApp.Models;
using GoldenShoeMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenShoeMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoeDetails : ContentPage
    {
        public ShoeDetails()
        {
            BindingContext = AppData.DisplayDetails;

            // Initialise the component
            InitializeComponent();
        }


    }
}
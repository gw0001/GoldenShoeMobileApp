using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenShoeMobileApp.Models
{
    public class ShoeModel
    {
        // --- SHOE MODEL VARIABLES --- //
        #region Shoe Model Variables
        private string _shoeName; // Shoe name
        private float _shoePrice; // Shoe price
        private string _shoeType; // Shoe type
        private ShoeCategory _shoeCategory; // Shoe category
        private string _shoeImageURI; // Shoe image URI
        private string _shoeShortDescription; // Shoe short description
        private string _shoeDescription; // Shoe description
        private string _shoeId; // Shoe Id
        private int _shoeQuantity; // Shoe quantity
        private string _shoeStockMessage; // Shoe quantity message
        private string _shoeStockMessageColour; // Colour for the shoe quantity
        private bool _canBuy; // Can buy boolean
        private string _buttonText; // Button text
        private string _buttonColour; // Button colour

        private const int LowLevelStock = 10; // Low Level Stock limit
        #endregion Shoe Model Variables 

        // --- SHOE MODEL ENUMERATORS --- //
        #region Shoe Model Enumerators
        /// <summary>
        /// Shoe type enumerator with "men" and "women" as
        /// values
        /// </summary>
        public enum ShoeType
        {
            men = 0,
            women = 1
        }

        /// <summary>
        /// Shoe category with "casual", "formal", and "work"
        /// as the category
        /// </summary>
        public enum ShoeCategory
        {
            casual = 0,
            formal = 1,
            sport = 2
        }
        #endregion Shoe Model Enumerators

        // --- SHOE MODEL GET AND SET METHODS --- //
        #region Shoe Model GetSet Methods

        /// <summary>
        /// Method is used to set and return the value held by
        /// the shoe name variable
        /// </summary>
        public string Name
        {
            get
            {
                return _shoeName;
            }
            set
            {
                _shoeName = value;
            }
        }

        /// <summary>
        /// Method is used to set and return the value held by
        /// the shoe price variable
        /// </summary>
        public float Price
        {
            get
            {
                return _shoePrice;
            }
            set
            {
                _shoePrice = value;
            }
        }

        /// <summary>
        /// Method is used to set and return the value held by
        /// the shoe type variable
        /// </summary>
        public string Type
        {
            get
            {
                return _shoeType;
            }
            set
            {
                _shoeType = value;
            }
        }

        /// <summary>
        /// Method is used to set and return the value held by
        /// the shoe category variable
        /// </summary>
        public ShoeCategory Category
        {
            get
            {
                return _shoeCategory;
            }
            set
            {
                _shoeCategory = value;
            }
        }

        /// <summary>
        /// Method is used to set and return the value held by
        /// the shoe image URI variable
        /// </summary>
        public string Image
        {
            get
            {
                return _shoeImageURI;
            }
            set
            {
                _shoeImageURI = value;
            }
        }

        /// <summary>
        /// Method is used to set and return the value held by the 
        /// shoe short description variable
        /// </summary>
        public string ShortDescription
        {
            get
            {
                return _shoeShortDescription;
            }
            set
            {
                _shoeShortDescription = value;
            }
        }

        /// <summary>
        /// Method is used to set and return the value held by the 
        /// shoe description variable
        /// </summary>
        public string Description
        {
            get
            {
                return _shoeDescription;
            }
            set
            {
                _shoeDescription = value;
            }
        }

        /// <summary>
        /// Method is used to set and return the value held by the 
        /// shoe description variable
        /// </summary>
        public int Quantity
        {
            get
            {
                return _shoeQuantity;
            }
            set
            {
                _shoeQuantity = value;
            }
        }

        /// <summary>
        /// Method used to set and return the value held by the 
        /// shoe stock message variable
        /// </summary>
        public string StockMessage
        {
            get
            {
                return _shoeStockMessage;
            }
            set
            {
                _shoeStockMessage = value;
            }
        }
        /// <summary>
        /// Method used to set and return the value held by the 
        /// shoe stock message colour variable
        /// </summary>
        public string StockMessageColour
        {
            get
            {
                return _shoeStockMessageColour;
            }
            set
            {
                _shoeStockMessageColour = value;
            }
        }

        /// <summary>
        /// Method is used to set and return the value held
        /// by the "can by" boolean
        /// </summary>
        public bool CanBuy
        {
            get
            {
                return _canBuy;
            }
            set
            {
                _canBuy = value;
            }
        }

        /// <summary>
        /// Method is used to set and return the value held
        /// by the button text variable
        /// </summary>
        public string ButtonText
        {
            get
            {
                return _buttonText;
            }
            set
            {
                _buttonText = value;
            }
        }

        /// <summary>
        /// Method is used to set and return the value held
        /// by the button colour variable
        /// </summary>
        public string ButtonColour
        {
            get
            {
                return _buttonColour;
            }
            set
            {
                _buttonColour = value;
            }
        }

        /// <summary>
        /// Method is used to set and return the value held
        /// by the shoe ID variable
        /// </summary>
        public string ShoeId
        {
            get
            {
                return _shoeId;
            }
            set
            {
                _shoeId = value;
            }
        }
        #endregion Shoe Model GetSet Methods

        // --- SHOE MODEL CONSTRUCTORS --- //
        #region Shoe Model Constructors

        /// <summary>
        /// Empty constructor for the shoe model
        /// </summary>
        public ShoeModel()
        {

        }

        /// <summary>
        /// Constructor for the shoe model that takes in shoe name,
        /// shoe price, shoe type, shoe category, image URL, 
        /// </summary>
        public ShoeModel(string shoeName, float shoePrice, string shoeType, ShoeCategory shoeCategory, string shoeImageURI, string shoeShortDescription, string shoeDescription, int shoeQuantity, string shoeId)
        {
            Name = shoeName; // Shoe name
            Price = shoePrice; // Shoe price
            Type = shoeType; // Shoe type
            Category = shoeCategory; // Shoe category
            Image = shoeImageURI; // Shoe image URI
            ShortDescription = shoeShortDescription; // Shoe short description
            Description = shoeDescription; // Shoe description
            Quantity = shoeQuantity; // Set the shoe quantity
            ShoeId = shoeId; // Set the shoe id

            // Invoke the Set Stock Message and Colour method to set message and message colour variables
            SetStockMessageAndColour();

            // Set up the button to allow or disallow purchase
            SetUpButton();

        }

        /// <summary>
        /// Method checks the number of stock remaining
        /// and sets the appropriate message and message colour.
        /// If the stock is greater than the low level stock
        /// limit, an in stock message and light green colour is 
        /// set. If the stock is within the low stock range,
        /// a low stock message and colour is set. If neither of
        /// these are set, the message and colour are set to represent
        /// the item being out of stock
        /// </summary>
        private void SetStockMessageAndColour()
        {
            // Check if the shoe quantity is greater than or equal to the low level stock limit
            if(Quantity >= LowLevelStock)
            {
                // Set the stock message to "In Stock"
                StockMessage = "In stock";

                // Set the message colour to light green
                StockMessageColour = "LightGreen";

                // Set can buy to true
                CanBuy = true;
            }
            // Else, check if the stock is within the low stock range ( 0 < stock < low stock limit)
            else if(Quantity > 0 && Quantity < LowLevelStock)
            {
                // Set the stock message to a low level message and include the quantity remaining
                StockMessage = "Last " + Quantity + " in stock";

                // Set the message to orange
                StockMessageColour = "Orange";

                // Set can buy to true
                CanBuy = true;
            }
            // Else, item is considered out of stock
            else
            {
                // Set the stock message to the out of stock message 
                StockMessage = "Out of stock";

                // Set the message colour to orange red
                StockMessageColour = "OrangeRed";

                // Set can buy to false
                CanBuy = false;
            }
        }

        /// <summary>
        /// Method is used to set up the necessary
        /// settings to the button on the shoe details
        /// page
        /// </summary>
        private void SetUpButton()
        {
            // check if the item can be purchased
            if (CanBuy)
            {
                // Set text to allow user to add to cart
                _buttonText = "Add to Cart";

                // Set the colour to Goldenrod
                _buttonColour = "Goldenrod";
            }
            // Else, item is considered out of stock
            else
            {
                // Set the text to show the item is unavailable
                _buttonText = "Unavailable";

                // Set button to grey colour
                _buttonColour = "Gray";
            }
        }

        #endregion Shoe Model Constructors
    }
}
using System;
using System.Collections.Generic;
using GoldenShoeMobileApp.Models;
using System.Text;

namespace GoldenShoeMobileApp.ViewModels
{
    class CartViewModel : BaseViewModel
    {
        private List<OrderModel> _orders; // Order list
        private int _totalItems = 0; // Total items initialised to 0
        private float _totalCost = 0f; // Total cost intialised to 0f
        private string _cartMessage = ""; // Cart message

        public CartViewModel()
        {
            // Obtain the cart 
            Orders = GetCart();

            // Set the total number of items
            SetTotalItems();

            // Set the total cost
            SetTotalCost();

            // Set cart message
            SetCartMessage();
        }

        /// <summary>
        /// Retuns the order list of the cart
        /// </summary>
        public List<OrderModel> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Returns the total number of items in the shopping
        /// cart
        /// </summary>
        public int TotalItems
        {
            get
            {
                return _totalItems;
            }
            set
            {
                _totalItems = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Returns and sets the total cost of the items
        /// in the shopping cart
        /// </summary>
        public float TotalCost
        {
            get
            {
                return _totalCost;
            }
            set
            {
                _totalCost = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Returns and sets the value of the cart
        /// message variable
        /// </summary>
        public string CartMessage
        {
            get
            {
                return _cartMessage;

            }
            set
            {
                _cartMessage = value;
            }
        }

        /// <summary>
        /// Method determines the message that will be presented to the user
        /// </summary>
        public void SetCartMessage()
        {
            // Set total items to 0
            if (TotalItems == 0)
            {
                // Set cart message to show it is empty
                CartMessage = "Your shopping cart is empty...";
            }
            else
            {
                // Update cart message with the number of items in the cart
                CartMessage = "You have " + TotalItems + " in your shopping cart.";

            }
        }

        /// <summary>
        /// Method is used to obtain the total number
        /// of items in the cart
        /// </summary>
        public void SetTotalItems()
        {
            // Sum initialised to 0
            int sum = 0;

            // Iterate over all items in the order list
            foreach (var order in Orders)
            {
                // Add the sub quantity from the order list
                sum += order.SubQuantity;
            }

            // Set the total items to the sum
            TotalItems = sum;
        }

        /// <summary>
        /// Used to obtain the total cost of the order
        /// </summary>
        public void SetTotalCost()
        {
            // Sum initialised to 0f
            float sum = 0f;

            // iterate over each order
            foreach (var order in Orders)
            {
                // Add the sub total from the order
                sum += order.SubTotal;
            }

            // Set the total cost to the sum
            TotalCost = sum;
        }

        /// <summary>
        /// Temporary method for creating mock data
        /// </summary>
        /// <returns></returns>
        private List<OrderModel> GetCart()
        {

            // Create a new empty order list
            List<OrderModel> orderList = new List<OrderModel>();

            // Iterate over all of the orders
            foreach (OrderModel order in AppData.Cart)
            {
                orderList.Add(order);
            }

            // Return the list of featured shoes
            return orderList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenShoeMobileApp.Models
{
    public class OrderModel
    {
        // --- Order Model Variables --- //
        #region Order Model Variables

        private ShoeModel _shoe; // Shoe
        private int _subQuantity = 0; // Quantity initialised to 0
        private float _subTotal; // Subtotal

        #endregion Order Model Variables

        // --- Order Model Constructor --- //
        #region Order Model Constructor

        /// <summary>
        /// Empty constructor for order model
        /// </summary>
        public OrderModel()
        {

        }

        #endregion Order Model Constructor

        // --- Order Model Methods --- //
        #region Order Model Methods

        /// <summary>
        /// Method returns the value held by the 
        /// shoe variable
        /// </summary>
        public ShoeModel Shoe 
        { 
            get
            {
                return _shoe;
            }
            set
            {
                _shoe = value;
            }
        }

        /// <summary>
        /// Method returns the value held by the 
        /// sub quantity variable
        /// </summary>
        public int SubQuantity
        {
            get
            {
                return _subQuantity;
            }
            set
            {
                _subQuantity = value;
            }
        }

        /// <summary>
        /// Method returns the value held by the
        /// subtotal variable
        /// </summary>
        public float SubTotal
        {
            get
            {
                return _subTotal;
            }
            set
            {
                _subTotal = value;
            }
        }

        /// <summary>
        /// Method calculates the Sub total
        /// of the order based on the quantity and
        /// price of the item
        /// </summary>
        public void CalculateSubTotal()
        {
            SubTotal = SubQuantity * Shoe.Price;
        }

        #endregion Order Model Methods
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GoldenShoeMobileApp.Models;

public class AppData
{
    #region App Data Variables

    private static bool _shoeListPopulated = false; // Private shoe list populated Boolean

    #endregion App Data Variables

    #region App Data Methods

    /// <summary>
    /// Method allows for a shoe model to be
    /// returned or set
    /// </summary>
    public static ShoeModel DisplayDetails { get; set; }

    /// <summary>
    /// Method allows for a shoe model to be
    /// returned or set
    /// </summary>
    public static List<ShoeModel> ShoeList { get; set; } = new List<ShoeModel>();

    public static List<OrderModel> Cart { get; set; } = new List<OrderModel>();



    /// <summary>
    /// Method is used to pupulate the global shoe list
    /// </summary>
    public static void PopulateShoeList()
    {
        // Check if the shoe list boolean is false
        if(!_shoeListPopulated)
        {
            // Create a new list and populate with shoe data
            ShoeList = new List<ShoeModel>
            {
                // Populate the inventory with mens shoes
                new ShoeModel("V7 Running Shoes", 39.99f, "Mens", ShoeModel.ShoeCategory.sport, "mens_sport01.jpg", "New Balance low profile running shoes", "New Balance low profile, lace up, trail running shoes. With EVA midsole and breathable mesh for added comfort.", 20, "M0001"),
                new ShoeModel("Salomon Supera Running Shoes", 59.99f, "Mens", ShoeModel.ShoeCategory.sport, "mens_sport02.jpg", "Designed for easy terrain up to 40km", "Get prepared to tackle the trails with the perfect dose of comfort, grip and protection.", 10, "M0002"),
                new ShoeModel("Konhill Breathable Slip-On", 47.99f, "Mens", ShoeModel.ShoeCategory.casual, "mens_casual01.jpg", "Comfortable Non-Slip Walking Sneakers", "Smart looking casual deck-shoes that can slip on and off easily, with  breathability that prevent your feet from sweating.", 5, "M0003"),
                new ShoeModel("Cotswork Nailsworth", 42.99f, "Mens", ShoeModel.ShoeCategory.casual, "mens_casual02.jpg", "Stylish yet versatile", "Lace up casual shoe with Nubuck leather uppers, lightly padded collar for comfort and chunky sole", 25, "M0004"),
                new ShoeModel("Faranzi Tuxedo Shoes", 84.99f, "Mens", ShoeModel.ShoeCategory.formal, "mens_formal01.jpg", "Contemporary dress shoes", "Designed to match with any tuxedo or formal outfit. Its polished look will make you looking sharp and stand out at any wedding party or formal event.", 0, "M0005"),
                new ShoeModel("Floral Patent Derby Shoes", 27.99f, "Mens", ShoeModel.ShoeCategory.formal, "mens_formal02.jpg", "Fashionable and stylish", "Patent leather with floral design for fashion and style. Soft synthetic leather and breathe lining that form to your feet over time for all-day dry.", 0, "M0006"),

                // Populate the inventory with womens shoes
                new ShoeModel("Dykhmate Running Shoes", 40.99f, "Womens", ShoeModel.ShoeCategory.sport, "womens_sport01.jpg", "Perfect shoes for running", "The classic air cushion design and knitted upper material makes it possible for your feet to breathe freely when you run or walk.", 25, "W0001"),
                new ShoeModel("Leather Platform Shoes", 29.99f, "Womens", ShoeModel.ShoeCategory.casual, "womens_casual01.jpg", "Suitable for any season", "Finely stitched for lasting durability and style. These stunning shoes are perfect for casual events, working, walking, and running.", 12, "W0002"),
                new ShoeModel("Slip On Flat Shoes", 35.99f, "Womens", ShoeModel.ShoeCategory.casual, "womens_casual02.jpg", "Easy to wear and take off", "Comfortable shoes made from eco-friendly material. Lightweight, breathable, easy to wear and take off.", 7, "W0003"),
                new ShoeModel("Full Leather Slip On", 31.99f, "Womens", ShoeModel.ShoeCategory.formal, "womens_formal01.jpg", "Ideal for office and formal wear", "Leather upper and soft leather lining. Full leather footbed and deeply padded instep. Durable and flexible synthetic outer sole.", 5, "W0004"),
                new ShoeModel("Bridal Wedding Court Shoes", 48.99f, "Womens", ShoeModel.ShoeCategory.formal, "womens_formal02.jpg", "A nice pair of shoes", "Satin strappy heels have 2 inch block heels, and the buckle closure is very easy to wear. This classy shoes are good for any special occasion.", 0, "W0005"),
                new ShoeModel("H&B Zodiaco Sandals", 79.99f, "Womens", ShoeModel.ShoeCategory.formal, "womens_formal03.jpg", "Stylish with a snakeskin print", "These sandals feature a delicate buckle-fastening strap around the ankle, with a snakeskin print and patent mix upper. Perfect for summer occasions.", 0, "W0006")
            };

            // Set the shoe list populated as true to prevent further population
            _shoeListPopulated = true;
        }
    }

    /// <summary>
    /// A simple method that adds an item to the cart.
    /// If the cart is empty, the order is added to 
    /// the cart as its first element
    /// </summary>
    /// <param name="aShoe"></param>
    public static void AddItemToCart(ShoeModel aShoe)
    {
        // Check if the cart is empty
        if(Cart.Count == 0)
        {
            // Create a new order
            OrderModel newOrder = new OrderModel();

            // Set the shoe
            newOrder.Shoe = aShoe;

            // Initialise the quantity to 1
            newOrder.SubQuantity = 1;

            // Calculte the sub total
            newOrder.CalculateSubTotal();

            // Add the order to the cart
            Cart.Add(newOrder);

            // Return
            return;
        }
        else
        {
            // Repeat order boolean initialise to false
            bool repeatOrder = false;

            // Iterate over all orders in the cart
            foreach(OrderModel order in Cart)
            {
                // Compare the order in the shoe to the order
                if(order.Shoe.ShoeId == aShoe.ShoeId)
                {
                    // Increment the quantity by 1
                    order.SubQuantity++;

                    // Determine the subtotal
                    order.CalculateSubTotal();

                    // Set the repeat order to true
                    repeatOrder = true;

                    // Break the loop
                    break;
                }
            }

            // Check if the repeat order is false
            if(!repeatOrder)
            {
                // Create a new order
                OrderModel newOrder = new OrderModel();

                // Set the shoe
                newOrder.Shoe = aShoe;

                // Initialise the quantity to 1
                newOrder.SubQuantity = 1;

                // Calculte the sub total
                newOrder.CalculateSubTotal();

                // Add the order to the cart
                Cart.Add(newOrder);
            }
        }
    }

    #endregion App Data Methods
}
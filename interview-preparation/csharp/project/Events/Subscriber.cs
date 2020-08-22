using System;
using System.Collections.Generic;

namespace project.Events
{
    public class Subscriber
    {
        int id;
        public Subscriber(int id, Publisher pub)
        {
            this.id = id;
            pub.UpdateProduct += UpdateDatabase;
            pub.UpdateProduct += UpdateRedisCache;
            pub.UpdateProduct += UpdateShowCase;

            pub.LowStockNotification += NotifySupplyChain;
            pub.AddToStockNotifiation += NotifyNewItem;
        }

        /// <summary>
        /// Will persist Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateRedisCache(object sender, LowStockChangeObjectEventArgs e)
        {
            Console.WriteLine($"Id: {id} - Updating item {e.ProductName} on Redis Cache");
        }


        /// <summary>
        /// Remove Item from showcase
        /// It could send to the queue to update the Showcase bounded context
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateShowCase(object sender, LowStockChangeObjectEventArgs e)
        {
            Console.WriteLine($"Id: {id} - Updating item {e.ProductName} on Showcase");
        }

        /// <summary>
        /// Will persist Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateDatabase(object sender, LowStockChangeObjectEventArgs e)
        {
            Console.WriteLine($"Id: {id} - Update item {e.ProductName} on Database");
        }


        /// <summary>
        /// Will notify the SupplyChain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifySupplyChain(object sender, LowStockMessageEventArgs e)
        {
            Console.WriteLine($"Id: {id} - Notification - Item {e.ProductName} in low stock");
        }

        private void NotifyNewItem(object sender, AddStockMessageEventArgs e)
        {
            Console.WriteLine($"Id: {id} - Notification - New Item {e.ProductName} in stock = " + e.Stock);
        }
    }
  }
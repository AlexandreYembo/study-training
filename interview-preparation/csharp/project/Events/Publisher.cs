using System;

namespace project.Events
{
  public class Publisher
    {
        public void RemoveStock(ProductStockModel product, int qty)
        {
            if(product.HasLowStock(qty))
            {
                OnLowStock(new LowStockChangeObjectEventArgs(product.Total, product.Name));
                OnNotification(LowStockNotification, new LowStockMessageEventArgs(product.Name));
            }
        }

        public void AddToStock(ProductStockModel product, int qty)
        {
           product.AddTotal(qty);
           OnNotification(AddToStockNotifiation, new AddStockMessageEventArgs(qty, product.Name));
        }

        /// <summary>
        /// Could persist this event on Database -> this will update the product as inactive
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnLowStock(LowStockChangeObjectEventArgs e)
        {
            EventHandler<LowStockChangeObjectEventArgs> handler = UpdateProduct;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Notification or email to the customer or the supply chain asking to buy more items
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnNotification<T>(EventHandler<T> handler, T e)
        {
            if(handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<LowStockChangeObjectEventArgs> UpdateProduct;
        public event EventHandler<LowStockMessageEventArgs> LowStockNotification;
        public event EventHandler<AddStockMessageEventArgs> AddToStockNotifiation;
    }
}
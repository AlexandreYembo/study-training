using System;

namespace project.Events
{
    public class LowStockMessageEventArgs : EventArgs
    {
        public LowStockMessageEventArgs(string productName)
        {
            ProductName = productName;
        }
        public string ProductName { get; set; }
       public string Message { get; set; } = "Product in low stock";
    }
}
namespace project.Events
{
    public class AddStockMessageEventArgs
    {
         public AddStockMessageEventArgs(int stock, string productName)
        {
            Stock = stock;
            ProductName = productName;
        }

        public string ProductName { get; set; }
        public int Stock { get; set; }
    }
}
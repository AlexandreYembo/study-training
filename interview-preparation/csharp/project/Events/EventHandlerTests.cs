namespace project.Events
{
    public class EventHandlerTests
    {
        public void Test()
        {
            var pub = new Publisher();
            Subscriber sb = new Subscriber(1, pub);
            Subscriber sb2 = new Subscriber(2, pub);
           // Subscriber sb3 = new Subscriber(3, pub);
         //   Subscriber sb4 = new Subscriber(4, pub);

            var product = new ProductStockModel(1, 2, "Product A"); // get from Catalog context
            pub.RemoveStock(product, 2);
            //pub.AddToStock(product, 10);

            var product2 = new ProductStockModel(1, 2, "Product B"); // get from Catalog context
            pub.RemoveStock(product2, 4);
          //  pub.AddToStock(product, 10);
        }
    }
}
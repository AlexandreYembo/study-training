using System;

namespace project.Events
{
    public class ProductStockModel
    {
        public ProductStockModel(int minStock, int total, string name)
        {
            MinStock = minStock;
            Total = total;
            Name = name;
        }

        internal bool HasLowStock(int qty)
        {
            Total -= qty;
            return (Total < MinStock);
        }

        public int MinStock { get; private set; }
        public int Total { get; private set; }

        public string Name { get; private set; }

        internal void AddTotal(int qty)
        {
           Total += qty;
        }
    }
}



using System;

namespace Project0.Products
{
    public class Product : IProduct
    {
        public int ProductId { get; }
        public string Name { get; }
        public DateTime? BestBy { get; }
        public decimal UnitPrice { get; set; }

        public Product(string name, DateTime? bestBy, decimal unitPrice, int productId = 0)
        {
            ProductId = productId;
            Name = name;
            BestBy = bestBy;
            UnitPrice = unitPrice;
        }
    }
}
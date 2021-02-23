using System;


namespace Project0.Products
{
    public interface IProduct
    {
        int ProductId { get; }
        string Name { get; }
        DateTime? BestBy { get; }
        decimal UnitPrice { get; set; }
    }
}

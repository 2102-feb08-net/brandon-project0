using System;


namespace Project0.Products
{
    public interface IProduct
    {
        int ProductId { get; set; }
        string Name { get; set; }
        DateTime? BestBy { get; set; }
        decimal UnitPrice { get; set; }
    }
}

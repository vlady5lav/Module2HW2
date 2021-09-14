namespace TestShop.Models
{
    public class Order
    {
        public uint? ID { get; set; }

        public Product[] Products { get; set; }

        public double? Total { get; set; }
    }
}

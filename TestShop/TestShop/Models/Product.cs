namespace TestShop.Models
{
    public class Product
    {
        public uint? ID { get; set; }

        public string Name { get; set; }

        public double? Cost { get; set; }

        public Currency Currency { get; set; }

        public uint? Quantity { get; set; }
    }
}

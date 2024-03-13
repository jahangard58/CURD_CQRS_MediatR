namespace Product_CQRS_MediatR.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string? ProductName { get; set; } = null;
        public double? Price { get; set; } = 0;
    }
}

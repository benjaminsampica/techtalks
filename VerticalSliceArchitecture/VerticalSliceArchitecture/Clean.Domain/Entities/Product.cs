namespace Clean.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
    }
}

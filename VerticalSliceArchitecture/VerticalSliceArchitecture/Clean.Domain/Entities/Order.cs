using Clean.Domain.Entities;
using System.Collections.Generic;

namespace Clean.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }

        public void AddProducts(params Product[] products)
            => Products.AddRange(products);

        public List<Product> Products { get; } = new();

        // Other properties.
    }
}

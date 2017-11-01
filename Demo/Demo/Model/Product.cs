using System;

namespace Demo.Model
{
    public class Product
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime CreateOn { get; set; }

    }
}

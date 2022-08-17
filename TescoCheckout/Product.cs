using System;
using System.Collections.Generic;
using System.Text;

namespace TescoCheckout
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<SpecialPrice> SpecialPrices { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TescoCheckout
{
    public class CheckOut
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal FinalPrice { get; set; }
    }
}

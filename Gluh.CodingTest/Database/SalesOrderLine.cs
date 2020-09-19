using System;
using System.Collections.Generic;
using System.Text;

namespace Gluh.CodingTest.Database
{
    public class SalesOrderLine
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
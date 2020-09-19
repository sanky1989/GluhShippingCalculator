using System;
using System.Collections.Generic;
using System.Text;

namespace Gluh.CodingTest.Database
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ProductType Type { get; set; }

        /// <summary>
        /// Weight in kilograms
        /// </summary>
        public decimal Weight { get; set; }
    }

    public enum ProductType
    {
        Physical = 0,
        NonPhysical = 1,
        Service = 2
    }
}
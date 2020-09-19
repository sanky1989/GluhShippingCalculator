using System;
using System.Collections.Generic;
using System.Text;

namespace Gluh.CodingTest.Database
{
    public class ShippingPriceRate
    {
        /// <summary>
        /// Minimum price for this shipping rate to apply
        /// </summary>
        public decimal PriceMin { get; set; }

        /// <summary>
        /// Maximum price for this shipping rate to apply
        /// </summary>
        public decimal? PriceMax { get; set; }

        /// <summary>
        /// Shipping rate in dollars
        /// </summary>
        public decimal Rate { get; set; }

       
    }
}
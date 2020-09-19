using System;
using System.Collections.Generic;
using System.Text;

namespace Gluh.CodingTest.Database
{
    public class ShippingWeightRate
    {
        /// <summary>
        /// Minimum weight for this shipping rate to apply
        /// </summary>
        public decimal WeighMin { get; set; }

        /// <summary>
        /// Maximum weight for this shipping rate to apply
        /// </summary>
        public decimal? WeighMax { get; set; }

        /// <summary>
        /// Shipping rate in dollars
        /// </summary>
        public decimal Rate { get; set; }
    }
}
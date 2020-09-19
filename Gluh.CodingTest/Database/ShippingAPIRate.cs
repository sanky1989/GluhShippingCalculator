using System;
using System.Collections.Generic;
using System.Text;

namespace Gluh.CodingTest.Database
{
    public class ShippingAPIRate
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
        /// Dollar amount to adjust the API calculated rate
        /// </summary>
        public decimal? RateAdjustmentPrice { get; set; }

        /// <summary>
        /// Percentage to adjust the API calculated rate
        /// </summary>
        public decimal? RateAdjustmentPercent { get; set; }
    }
}

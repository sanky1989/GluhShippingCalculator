using System;
using System.Collections.Generic;
using System.Text;

namespace Gluh.CodingTest
{
    /// <summary>
    /// Simulates calculating a shipping rate from a 3rd party API
    /// </summary>
    public class ShippingApiClient
    {
        public decimal GetRate(decimal postalCodeFrom, decimal postalCodeTo, decimal weight)
        {
            if (weight <= 5)
            {
                return weight * 2.5m;
            }
            else if (weight <= 10)
            {
                return weight * 1.5m;
            }
            else if (weight <= 20)
            {
                return weight * 1.25m;
            }
            else
            {
                return weight * 1.15m;
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using Gluh.CodingTest.Database;

namespace Gluh.CodingTest
{
    public class ShippingCalculator
    {

        private List<ShippingPriceRate> _priceRates;
        private List<ShippingWeightRate> _weightRates;
        private List<ShippingAPIRate> _apiRates;

        public ShippingCalculator()
        {
            _priceRates = new List<ShippingPriceRate>
            {
                new ShippingPriceRate { PriceMin = 0, PriceMax = 50, Rate = 5.50m },
                new ShippingPriceRate { PriceMin = 0, PriceMax = 100, Rate = 0.00m },
                new ShippingPriceRate { PriceMin = 100, PriceMax = 500, Rate = 10.00m },
                new ShippingPriceRate { PriceMin = 1000, PriceMax = null, Rate = 15.00m },
            };
            _weightRates = new List<ShippingWeightRate>
            {
                new ShippingWeightRate { WeighMin = 1, WeighMax = 5, Rate = 10.00m },
                new ShippingWeightRate { WeighMin = 5.01m, WeighMax = 10.00m, Rate = 7.00m },
                new ShippingWeightRate { WeighMin = 10.00m, WeighMax = null, Rate = 20.00m }
            };
            _apiRates = new List<ShippingAPIRate>
            {
                new ShippingAPIRate { WeighMin = 10, WeighMax = 30, RateAdjustmentPrice = 5m },
                new ShippingAPIRate { WeighMin = 30, WeighMax = 35, RateAdjustmentPercent = 7.5m },
                new ShippingAPIRate { WeighMin = 35, WeighMax = null }
            };
        }

        /// <summary>
        /// Calculates the shipping price for a sales order
        /// ### Complete this method
        /// </summary>
        /// Assumptions
        /// Price Based Shipping Rate Calculations: Total Price of all the products in the order is considered to calculate the shipping rate for Price Based Method
        /// Weight Based Shipping Rate Calcuations: Total Weight of all the products in the order is considered to calculate the shipping rate for Weight Based Method
        /// API Based Shipping Rate Calcuations: There is little bit confusion on this part of calculations. Here my understanding suggested that if product weighs between 10 to 30 I have added 5m to Weight based calculation
        /// I thought to get maximum from Price Based and Weight based and add the rate adjustment price to it. Similar approach is used for Rate Adjustment Percent.
        public decimal Calculate(SalesOrder salesOrder)
        {
            //throw new NotImplementedException();
            decimal shippingCost = 0.00m;
           
           // decimal ShippingAPICost = 0.00m;
            if (salesOrder != null && salesOrder.Lines.Count() > 0)
            {
                decimal TotalPrice =0.00m;
                decimal TotalWeight = 0.00m;

                foreach (SalesOrderLine orderLine in salesOrder.Lines)
                {
                    TotalPrice += (orderLine.Price * orderLine.Quantity);
                    if (orderLine.Product != null)
                        TotalWeight += (orderLine.Product.Weight * orderLine.Quantity);
                }

                ShippingCalculator shippingCalculator = new ShippingCalculator();
                var ShippingPriceCost = CalculateShippingRate(TotalPrice, shippingCalculator._priceRates);
                var ShippingWeightCost = CalculateShippingRate(TotalWeight, shippingCalculator._weightRates);
                //var ApiCalculatedWeight =  ShippingApiClient.get
                var shippingapiclient = new ShippingApiClient();
                var apiweightCost = shippingapiclient.GetRate(decimal.Parse( salesOrder.DeliveryPostalCode), decimal.Parse(salesOrder.DeliveryPostalCode), TotalWeight);
                var ShippingAPICost = CalculateShippingRate(TotalWeight, shippingCalculator._apiRates, apiweightCost);
                shippingCost = GetMax(ShippingPriceCost, ShippingWeightCost, ShippingAPICost);

            }


            return shippingCost;

        }
        public decimal CalculateShippingRate(decimal TotalPrice, List<ShippingPriceRate> shippingPriceRates)
        {
            decimal shippingPriceRate = shippingPriceRates.Where(w => TotalPrice >= w.PriceMin && (TotalPrice <= w.PriceMax || w.PriceMax == null )).Select(s=> s.Rate).DefaultIfEmpty().Max();
            return shippingPriceRate;
        }

        public decimal CalculateShippingRate(decimal TotalWeight, List<ShippingWeightRate> shippingWeightRates)
        {
            decimal shippingWeightRate = shippingWeightRates.Where(w => TotalWeight >= w.WeighMin && (TotalWeight <= w.WeighMax || w.WeighMax == null)).Select(s => s.Rate).DefaultIfEmpty().Max();
            return shippingWeightRate;
        }
        public decimal CalculateShippingRate(decimal TotalWeight, List<ShippingAPIRate> shippingAPIRates, decimal ShippingWeightCost)
        {
            decimal retVal = 0.00m;
            var shippingAPIWeightRate =  shippingAPIRates.Where(w => TotalWeight >= w.WeighMin && (TotalWeight <= w.WeighMax || w.WeighMax == null)).ToList();
            if (shippingAPIWeightRate.Count() > 0 && ShippingWeightCost != 0.00m)
            {
                foreach (ShippingAPIRate apiRate in shippingAPIWeightRate)
                {
                    var tempRate = 0.00m;
                    if (apiRate.RateAdjustmentPrice.HasValue)
                    {
                        tempRate = ShippingWeightCost + apiRate.RateAdjustmentPrice.Value;
                        if (retVal < tempRate)
                            retVal = tempRate;
                    }
                    if (apiRate.RateAdjustmentPercent.HasValue)
                    {
                        tempRate = ShippingWeightCost + (ShippingWeightCost * apiRate.RateAdjustmentPercent.Value / 100);
                        if (retVal < tempRate)
                            retVal = tempRate;
                    }

                }


            }

            return retVal;
        }

        public static decimal GetMax(decimal shippingPriceRate, decimal shippingWeightRate,decimal shippingAPIRate)
        {
            return Math.Max(shippingPriceRate, Math.Max( shippingWeightRate, shippingAPIRate));
        }


    }
}

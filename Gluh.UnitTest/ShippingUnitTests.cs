using NUnit.Framework;
using Gluh.CodingTest.Database;
using Gluh.CodingTest;

namespace Gluh.UnitTest
{

    public class ShippingUnitTests
    {
        private SalesOrder order;

        [SetUp]
        public void Setup()
        {
            order = new SalesOrder();
            order.ID = 1;
            order.OrderNumber = "1001";
            order.DeliveryAddress = "653 Burwood Highway";
            order.DeliveryState = "VIC";
            order.DeliveryPostalCode = "3156";
        }

        #region Return Equal Price Rates
        [Test]
        public void ReturnsEqualPriceRates()
        {
            Setup();
            //Price based rate returns 10.00m and Weight based  rate returns 10.00m
            var ExpectedValue = 10.00m;
            var orderline = new SalesOrderLine();
            orderline.Price = 240.00m;
            orderline.Quantity = 1;
            orderline.Product = new Product();
            orderline.Product.ID = 1;
            orderline.Product.Name = "GPS Navigation System";
            orderline.Product.Type = ProductType.Physical;
            orderline.Product.Weight = 4.30m;
            //First Product added
            order.Lines.Add(orderline);
            orderline = new SalesOrderLine();
            orderline.Price = 120.00m;
            orderline.Quantity = 1;
            orderline.Product = new Product();
            orderline.Product.ID = 2;
            orderline.Product.Name = "Nav Installation";
            orderline.Product.Type = ProductType.Service;
            orderline.Product.Weight = 0.00m;
            //Second Product added
            order.Lines.Add(orderline);
            ShippingCalculator shippingCalculator = new ShippingCalculator();
            var price = shippingCalculator.Calculate(order);
            Assert.AreEqual(ExpectedValue, price);

        }

        #endregion


        #region Weight Based Tests
        [Test]
        public void Returns_10_WeightBasedPriceRates()
        {

            Setup();
            //Weight based rate returns 10.00m while Price based returns 0.00m. API returns null
            var ExpectedValue = 10.00m;
            var orderline = new SalesOrderLine();
            orderline.Price = 51.00m;
            orderline.Quantity = 1;
            orderline.Product = new Product();
            orderline.Product.ID = 3;
            orderline.Product.Name = "Portable GPS";
            orderline.Product.Type = ProductType.Physical;
            orderline.Product.Weight = 2.50m;
            //First Product added
            order.Lines.Add(orderline);
            ShippingCalculator shippingCalculator = new ShippingCalculator();
            var price = shippingCalculator.Calculate(order);
            Assert.AreEqual(ExpectedValue, price);

        }
        [Test]
        public void Returns_7_WeightBasedPriceRates()
        {

            Setup();
            //Weight based rate returns 7.00m while Price based returns 5.50m. API returns null
            var ExpectedValue = 7.00m;
            var orderline = new SalesOrderLine();
            orderline.Price = 2.00m;
            orderline.Quantity = 12;
            orderline.Product = new Product();
            orderline.Product.ID = 4;
            orderline.Product.Name = "Charging Cable";
            orderline.Product.Type = ProductType.Physical;
            orderline.Product.Weight = 0.50m;
            //First Product added
            order.Lines.Add(orderline);
            ShippingCalculator shippingCalculator = new ShippingCalculator();
            var price = shippingCalculator.Calculate(order);
            Assert.AreEqual(ExpectedValue, price);

        }


        [Test]
        public void Returns_20_WeightBasedPriceRates()
        {

            Setup();
            //Weight based rate returns 20.00m while Price based returns 0.00m. API returns null
            var ExpectedValue = 20.00m;
            var orderline = new SalesOrderLine();
            orderline.Price = 2.00m;
            orderline.Quantity = 12;
            orderline.Product = new Product();
            orderline.Product.ID = 4;
            orderline.Product.Name = "Charging Cable";
            orderline.Product.Type = ProductType.Physical;
            orderline.Product.Weight = 0.50m;
            //First Product added
            order.Lines.Add(orderline);

            orderline = new SalesOrderLine();
            orderline.Price = 15.00m;
            orderline.Quantity = 2;
            orderline.Product = new Product();
            orderline.Product.ID = 6;
            orderline.Product.Name = "Charging Socket Replacement Part";
            orderline.Product.Type = ProductType.Physical;
            orderline.Product.Weight = 24.50m;
            //Second Product added
            order.Lines.Add(orderline);

            ShippingCalculator shippingCalculator = new ShippingCalculator();
            var price = shippingCalculator.Calculate(order);
            Assert.AreEqual(ExpectedValue, price);

        }


        #endregion

        #region Price Based Tests
        [Test]
        public void Returns_5_5_PriceBasedPriceRates()
        {

            Setup();
            //Price based rate returns 5.50m , Weight based rate returns 0.00m , API returns 0.00m
            var ExpectedValue = 5.50m;
            var orderline = new SalesOrderLine();
            orderline.Price = 50.00m;
            orderline.Quantity = 1;
            orderline.Product = new Product();
            orderline.Product.ID = 7;
            orderline.Product.Name = "Cables & wires";
            orderline.Product.Type = ProductType.Physical;
            orderline.Product.Weight = 0.5m;
            //First Product added
            order.Lines.Add(orderline);
            ShippingCalculator shippingCalculator = new ShippingCalculator();
            var price = shippingCalculator.Calculate(order);
            Assert.AreEqual(ExpectedValue, price);

        }


        [Test]
        public void Returns_0_PriceBasedPriceRates()
        {

            Setup();
            //Price based rate returns 0.00m , Weight based rate returns 0.00m , API returns 0.00m
            var ExpectedValue = 0.00m;
            var orderline = new SalesOrderLine();
            orderline.Price = 55.99m;
            orderline.Quantity = 1;
            orderline.Product = new Product();
            orderline.Product.ID = 8;
            orderline.Product.Name = "Installation";
            orderline.Product.Type = ProductType.Service;
            //orderline.Product.Weight = 0.5m;
            //First Product added
            order.Lines.Add(orderline);
            ShippingCalculator shippingCalculator = new ShippingCalculator();
            var price = shippingCalculator.Calculate(order);
            Assert.AreEqual(ExpectedValue, price);

        }


        [Test]
        public void Returns_10_PriceBasedPriceRates()
        {

            Setup();
            //Price based rate returns 10.00m , Weight based rate returns 7.00m , API returns 0.00m
            var ExpectedValue = 10.00m;
            var orderline = new SalesOrderLine();
            orderline.Price = 150.00m;
            orderline.Quantity = 1;
            orderline.Product = new Product();
            orderline.Product.ID = 9;
            orderline.Product.Name = "Car Stereo";
            orderline.Product.Type = ProductType.Physical;
            orderline.Product.Weight = 5.5m;
            //First Product added
            order.Lines.Add(orderline);

            orderline = new SalesOrderLine();
            orderline.Price = 200.00m;
            orderline.Quantity = 1;
            orderline.Product = new Product();
            orderline.Product.ID = 10;
            orderline.Product.Name = "Car Stereo Installation";
            orderline.Product.Type = ProductType.Service;
            //orderline.Product.Weight = 5.5m;
            //Second Product added
            order.Lines.Add(orderline);


            ShippingCalculator shippingCalculator = new ShippingCalculator();
            var price = shippingCalculator.Calculate(order);
            Assert.AreEqual(ExpectedValue, price);

        }


        [Test]
        public void Returns_15_PriceBasedPriceRates()
        {

            Setup();
            //Price based rate returns 15.00m , Weight based rate returns 10.00m , API returns 0.00m
            var ExpectedValue = 15.00m;
            var orderline = new SalesOrderLine();
            orderline.Price = 300.00m;
            orderline.Quantity = 2;
            orderline.Product = new Product();
            orderline.Product.ID = 11;
            orderline.Product.Name = "Genuine Side Mirrors Honda";
            orderline.Product.Type = ProductType.Physical;
            orderline.Product.Weight = 2.5m;
            //First Product added
            order.Lines.Add(orderline);

            orderline = new SalesOrderLine();
            orderline.Price = 410.00m;
            orderline.Quantity = 1;
            orderline.Product = new Product();
            orderline.Product.ID = 12;
            orderline.Product.Name = "Side Mirror Installation";
            orderline.Product.Type = ProductType.Service;
            //orderline.Product.Weight = 5.5m;
            //Second Product added
            order.Lines.Add(orderline);


            ShippingCalculator shippingCalculator = new ShippingCalculator();
            var price = shippingCalculator.Calculate(order);
            Assert.AreEqual(ExpectedValue, price);

        }
        #endregion

        #region API Based Tests
        [Test]
        public void Returns_23_750_APIBasedPriceRates()
        {

            Setup();
            //Price based rate returns 10.00m , Weight based rate returns 20.00m , API returns 23.75m
            var ExpectedValue = 23.750m;
            var orderline = new SalesOrderLine();
            orderline.Price = 250.00m;
            orderline.Quantity = 1;
            orderline.Product = new Product();
            orderline.Product.ID = 13;
            orderline.Product.Name = "Car Front and Back Mirror";
            orderline.Product.Type = ProductType.Physical;
            orderline.Product.Weight = 15;
            //First Product added
            order.Lines.Add(orderline);
            ShippingCalculator shippingCalculator = new ShippingCalculator();
            var price = shippingCalculator.Calculate(order);
            Assert.AreEqual(ExpectedValue, price);

        }

        [Test]
        public void Returns_39_56_APIBasedPriceRates()
        {

            Setup();
            //Price based rate returns 15.00m , Weight based rate returns 20.00m , API returns 39.56m
            var ExpectedValue = 39.56m;
            var orderline = new SalesOrderLine();
            orderline.Price = 300.00m;
            orderline.Quantity = 4;
            orderline.Product = new Product();
            orderline.Product.ID = 14;
            orderline.Product.Name = "Car Tyres";
            orderline.Product.Type = ProductType.Physical;
            orderline.Product.Weight = 8;
            //First Product added
            order.Lines.Add(orderline);
            ShippingCalculator shippingCalculator = new ShippingCalculator();
            var price = shippingCalculator.Calculate(order);
            Assert.AreEqual(ExpectedValue, price);

        }

        #endregion

        #region Other Tests
        [Test]
        public void Returns_0_ZeroProducts()
        {
            Setup();
            ShippingCalculator shippingCalculator = new ShippingCalculator();
            var price = shippingCalculator.Calculate(order);
            Assert.AreEqual(0.00m, price);

        }

        [Test]
        public void Returns_ZeroforNegativeValues()
        {

            Setup();
            
            var ExpectedValue = 0.00m;
            var orderline = new SalesOrderLine();
            orderline.Price = -1.00m;
            orderline.Quantity = 4;
            orderline.Product = new Product();
            orderline.Product.ID = 15;
            orderline.Product.Name = "Affiliates Credit";
            orderline.Product.Type = ProductType.NonPhysical;
            //First Product added
            order.Lines.Add(orderline);
            ShippingCalculator shippingCalculator = new ShippingCalculator();
            var price = shippingCalculator.Calculate(order);
            Assert.AreEqual(ExpectedValue, price);

        }

        #endregion
    }
}
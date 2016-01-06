using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Marketplace.Interview.Business;
using Marketplace.Interview.Business.Basket;
using Marketplace.Interview.Business.Shipping;
using NUnit.Framework;

namespace Marketplace.Interview.Tests
{
    [TestFixture]
    public class ShippingOptionTests
    {
        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void TearDown()
        {
            string path = Path.Combine(Environment.GetEnvironmentVariable("temp"), "basket.xml");
            File.Delete(path);
        }

        [Test]
        public void BasketShippingTotalTest()
        {
            var perRegionShippingOption = new PerRegionShipping
            {
                PerRegionCosts = new[]
                {
                    new RegionShippingCost
                    {
                        DestinationRegion =
                            RegionShippingCost.Regions.UK,
                        Amount = .75m
                    },
                    new RegionShippingCost
                    {
                        DestinationRegion =
                            RegionShippingCost.Regions.Europe,
                        Amount = 1.5m
                    }
                },
            };

            var flatRateShippingOption = new FlatRateShipping {FlatRate = 1.1m};

            var basket = new Basket
            {
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        DeliveryRegion = RegionShippingCost.Regions.UK,
                        Shipping = perRegionShippingOption
                    },
                    new LineItem
                    {
                        DeliveryRegion = RegionShippingCost.Regions.Europe,
                        Shipping = perRegionShippingOption
                    },
                    new LineItem {Shipping = flatRateShippingOption},
                }
            };

            var calculator = new ShippingCalculator();

            decimal basketShipping = calculator.CalculateShipping(basket);

            Assert.That(basketShipping, Is.EqualTo(3.35m));
        }

        [Test]
        public void CustomShippingOptionTest()
        {
            IGetBasketQuery basketLoader = new GetBasketQuery();
            IAddToBasketCommand addToBasket = new AddToBasketCommand();
            IGetShippingOptionsQuery getShippingOptions = new GetShippingOptions();

            Dictionary<string, ShippingBase> shippingOptions =
                getShippingOptions.Invoke(new GetShippingOptionsRequest()).ShippingOptions;


            var lineItemList = new List<LineItem>
            {
                new LineItem
                {
                    Amount = 1.5m,
                    ProductId = "1",
                    Shipping = shippingOptions["CustomShipping"],
                    SupplierId = 1,
                    DeliveryRegion = CustomShippingCost.Regions.Europe,
                    ShippingAmount = 1m
                },
                new LineItem
                {
                    Amount = 1.5m,
                    ProductId = "1",
                    Shipping = shippingOptions["CustomShipping"],
                    SupplierId = 1,
                    DeliveryRegion = CustomShippingCost.Regions.Europe,
                    ShippingAmount = 0.5m
                },
                new LineItem
                {
                    Amount = 1.5m,
                    ProductId = "1",
                    Shipping = shippingOptions["CustomShipping"],
                    SupplierId = 1,
                    DeliveryRegion = CustomShippingCost.Regions.UK,
                    ShippingAmount = 0.5m
                },
                new LineItem
                {
                    Amount = 1.5m,
                    ProductId = "1",
                    Shipping = shippingOptions["CustomShipping"],
                    SupplierId = 1,
                    DeliveryRegion = CustomShippingCost.Regions.UK,
                    ShippingAmount = 0.0m
                },
                new LineItem
                {
                    Amount = 1.5m,
                    ProductId = "1",
                    Shipping = shippingOptions["CustomShipping"],
                    SupplierId = 1,
                    DeliveryRegion = CustomShippingCost.Regions.RestOfTheWorld,
                    ShippingAmount = 2m
                },
                new LineItem
                {
                    Amount = 1.5m,
                    ProductId = "1",
                    Shipping = shippingOptions["CustomShipping"],
                    SupplierId = 1,
                    DeliveryRegion = CustomShippingCost.Regions.RestOfTheWorld,
                    ShippingAmount = 1.5m
                }
            };

            foreach (LineItem item in lineItemList)
            {
                addToBasket.Invoke(new AddToBasketRequest {LineItem = item});
            }

            Basket basket = basketLoader.Invoke(new BasketRequest());

            foreach (LineItem item in basket.LineItems)
            {
                LineItem sampleListItem = lineItemList.FirstOrDefault(a => a.Id == item.Id);

                Assert.AreEqual(sampleListItem.SupplierId, item.SupplierId, "SupplierId are not equal");
                Assert.AreEqual(sampleListItem.DeliveryRegion, item.DeliveryRegion, "DeliveryRegion are not equal");
                Assert.AreEqual(sampleListItem.ShippingAmount, item.ShippingAmount, "ShippingAmount are not equal");
            }
        }

        [Test]
        public void FlatRateShippingOptionTest()
        {
            var flatRateShippingOption = new FlatRateShipping {FlatRate = 1.5m};
            decimal shippingAmount = flatRateShippingOption.GetAmount(new LineItem(), new Basket());

            Assert.That(shippingAmount, Is.EqualTo(1.5m), "Flat rate shipping not correct.");
        }

        [Test]
        public void PerRegionShippingOptionTest()
        {
            var perRegionShippingOption = new PerRegionShipping
            {
                PerRegionCosts = new[]
                {
                    new RegionShippingCost
                    {
                        DestinationRegion =
                            RegionShippingCost.Regions.UK,
                        Amount = .75m
                    },
                    new RegionShippingCost
                    {
                        DestinationRegion =
                            RegionShippingCost.Regions.Europe,
                        Amount = 1.5m
                    }
                },
            };

            decimal shippingAmount =
                perRegionShippingOption.GetAmount(new LineItem {DeliveryRegion = RegionShippingCost.Regions.Europe},
                    new Basket());
            Assert.That(shippingAmount, Is.EqualTo(1.5m));

            shippingAmount =
                perRegionShippingOption.GetAmount(new LineItem {DeliveryRegion = RegionShippingCost.Regions.UK},
                    new Basket());
            Assert.That(shippingAmount, Is.EqualTo(.75m));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Marketplace.Interview.Business.Basket;

namespace Marketplace.Interview.Business.Shipping
{
    public class AnotherShippingType : ShippingBase
    {
        public IEnumerable<AnotherShippingTypeCost> AnotherShippingTypeCosts { get; set; }

        public override string GetDescription(LineItem lineItem, Basket.Basket basket)
        {
            return string.Format("New Shipping to {0}", lineItem.DeliveryRegion);
        }

        public override decimal GetAmount(LineItem lineItem, Basket.Basket basket)
        {
            return
                AnotherShippingTypeCosts.Where(c => c.DestinationRegion == lineItem.DeliveryRegion).Select(m => m.Amount).Single()
             - GetDeductionAmount(lineItem, basket);
        }

        /// <summary>
        /// Check list for previously added records dependiong upon Region, supplierId and Shipping 
        /// </summary>
        /// <returns></returns>
        private decimal GetDeductionAmount(LineItem lineItem, Basket.Basket basket)
        {
            try
            {
                var anotherShippingData =
                    basket.LineItems.Where(m =>
                        m.Shipping.GetType() == typeof(AnotherShippingType) &&
                        m.DeliveryRegion == lineItem.DeliveryRegion &&
                        m.SupplierId == lineItem.SupplierId);
                return anotherShippingData.Any() && anotherShippingData.FirstOrDefault() != lineItem ? 0.5m : 0.0m;
            }
            catch (Exception ex)
            {
                return 0.0m;
            }

        }
    }
}
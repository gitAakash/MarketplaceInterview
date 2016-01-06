using System;
using System.Collections.Generic;
using System.Linq;
using Marketplace.Interview.Business.Basket;

namespace Marketplace.Interview.Business.Shipping
{
    public class CustomShipping : ShippingBase
    {
        public IEnumerable<CustomShippingCost> CustomShippingCosts { get; set; }

        public override string GetDescription(LineItem lineItem, Basket.Basket basket)
        {
            return string.Format("New Shipping to {0}", lineItem.DeliveryRegion);
        }

        public override decimal GetAmount(LineItem lineItem, Basket.Basket basket)
        {
            var customEntries = basket.LineItems.Where(m =>
                    m.Shipping.GetType() == typeof(CustomShipping) && m.DeliveryRegion == lineItem.DeliveryRegion &&
                    m.SupplierId == lineItem.SupplierId);
            return
                (from c in CustomShippingCosts
                 where c.DestinationRegion == lineItem.DeliveryRegion
                 select c.Amount).Single() - 
                 Convert.ToDecimal(customEntries.Count() > 1 && customEntries.FirstOrDefault() != lineItem ? 0.5d : 0.0d);
        }
    }
}
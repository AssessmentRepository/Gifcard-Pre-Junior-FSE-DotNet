using System;
using System.Collections.Generic;
using System.Text;

namespace GiftCards.Entities
{
    public class GiftOrder
    {
        public int GiftOrderId { get; set; }
        public string RecepientName { get; set; }
        public string ShippingAddress {get;set;}
        public int GiftId { get; set; }
        public int BuyerId { get; set; }
    }
}

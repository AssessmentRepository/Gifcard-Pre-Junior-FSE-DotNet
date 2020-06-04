using System;
using System.Collections.Generic;
using System.Text;

namespace GiftCards.Entities
{
   public class ContactUs
    {
        public int ContactUsId { get; set; }
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}

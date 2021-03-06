﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GiftCards.Entities
{
   public class Buyer
    {
        public int BuyerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
    }
}

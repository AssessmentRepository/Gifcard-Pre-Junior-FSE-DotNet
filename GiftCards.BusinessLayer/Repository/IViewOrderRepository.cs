using GiftCards.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiftCards.BusinessLayer.Repository
{
  public  interface IViewOrderRepository
    {
        Task<IEnumerable<GiftOrder>> ViewAllGiftCardOrders();
    }
}

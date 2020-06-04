using GiftCards.BusinessLayer.Interface;
using GiftCards.BusinessLayer.Repository;
using GiftCards.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiftCards.BusinessLayer.Services
{
    public class ViewOrderServices : IViewOrderServices
    {
        private readonly IViewOrderRepository _viewOrderRepository;

        public ViewOrderServices(IViewOrderRepository repository)
        {
            _viewOrderRepository = repository;
        }

      public   async Task<IEnumerable<GiftOrder>> ViewAllGiftCardOrders()
        {
            //also retrive count
            //Do code here
            throw new NotImplementedException();
        }
    }
}

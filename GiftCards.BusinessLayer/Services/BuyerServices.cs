using GiftCards.BusinessLayer.Interface;
using GiftCards.BusinessLayer.Repository;
using GiftCards.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiftCards.BusinessLayer.Services
{
    public class BuyerServices : IBuyerServices
    {
        private readonly IBuyerRepository _buyerrRepository;


        public BuyerServices(IBuyerRepository buyerrRepository)
        {

            _buyerrRepository = buyerrRepository;

        }

        public async Task<bool> RegisterAsync(Buyer buyer)
        {
            {
                try
                {
                   var result = await _buyerrRepository.Register(buyer);
                    return result;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }

        public async Task<IEnumerable<Buyer>> GetAllBuyersAsync()
        {
            try
            {
                var buyer = await _buyerrRepository.GetAllBuyersAsync();
                return buyer;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<bool> PlaceGiftOrderAsync(GiftOrder Order)
        {

            //Do code here
            throw new NotImplementedException();
        }
       

        public async Task<bool> ChangePassword(int BuyerId)
        {

            //Do code here
            throw new NotImplementedException();
        }

        public async Task<bool> GetBuyerByIdAsync(int BuyerId)
        {

            //Do code here
            throw new NotImplementedException();
        }

        public async Task<bool> Login(Buyer buyer)
        {

            //Do code here
            throw new NotImplementedException();
        }

        public async Task<bool> LogOut(Buyer buyer)
        {

            //Do code here
            throw new NotImplementedException();
        }


        public async Task<bool> PlaceOrderAsync(GiftOrder Order)
        {

            //Do code here
            throw new NotImplementedException();
        }
        
    }
}

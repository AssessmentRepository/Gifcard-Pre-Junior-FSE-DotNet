using GiftCards.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiftCards.BusinessLayer.Repository
{
   public interface IBuyerRepository
    {
        Task<bool> Register(Buyer buyer);
        Task<bool> Login(Buyer buyer);
        Task<bool> ChangePassword(int BuyerId);
        Task<bool> LogOut(Buyer buyer);
        Task<IEnumerable<Buyer>> GetAllBuyersAsync();
        Task<bool> GetBuyerByIdAsync(int BuyerId);

        Task<bool> PlaceGiftOrderAsync(GiftOrder Order);
    }
}

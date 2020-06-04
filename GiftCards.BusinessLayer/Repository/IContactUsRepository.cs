
using GiftCards.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiftCards.BusinessLayer.Repository
{
   public interface IContactUsRepository
    {
        Task<bool> ContactUs(ContactUs contact);
        Task<bool> DeleteContactUs(int ContactUsId);
        Task<bool> UpdateContactUs(int ContactUsId);
    }
}

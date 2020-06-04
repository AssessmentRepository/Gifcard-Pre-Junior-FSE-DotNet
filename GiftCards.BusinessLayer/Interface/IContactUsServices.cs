
using GiftCards.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiftCards.BusinessLayer.Interface
{
  public interface IContactUsServices
    {
        Task<bool> ContactUs(ContactUs contact);
        Task<bool> DeleteContactUs(int ContactUsId);
        Task<bool> UpdateContactUs(int ContactUsId);
    }
}

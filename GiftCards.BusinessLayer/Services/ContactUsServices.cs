using GiftCards.BusinessLayer.Interface;
using GiftCards.BusinessLayer.Repository;
using GiftCards.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiftCards.BusinessLayer.Services
{
    public class ContactUsServices : IContactUsServices
    {
        private readonly IContactUsRepository _contactRepository;

        public ContactUsServices(IContactUsRepository repository)
        {
            _contactRepository = repository;
        }

        public async Task<bool> ContactUs(ContactUs contact)
        {

            //Do code here
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteContactUs(int ContactUsId)
        {

            //Do code here
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateContactUs(int ContactUsId)
        {

            //Do code here
            throw new NotImplementedException();
        }

       
    }
}

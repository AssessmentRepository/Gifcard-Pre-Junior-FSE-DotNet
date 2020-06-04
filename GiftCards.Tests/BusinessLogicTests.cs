using GiftCards.BusinessLayer.Interface;
using GiftCards.BusinessLayer.Repository;
using GiftCards.BusinessLayer.Services;
using GiftCards.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GiftCards.Tests
{
    public class BusinessLogicTests
    {
        private IViewOrderServices _viworderservices;
        private IContactUsServices _contactusservices;
        private IBuyerServices _buyerservices;

        public readonly Mock<IBuyerRepository> buyerservice = new Mock<IBuyerRepository>();
        public readonly Mock<IViewOrderRepository> viworderservices = new Mock<IViewOrderRepository>();
        public readonly Mock<IContactUsRepository> contactusservices = new Mock<IContactUsRepository>();


        public BusinessLogicTests()
        {
            _buyerservices = new BuyerServices(buyerservice.Object);
            _viworderservices = new ViewOrderServices(viworderservices.Object);
            _contactusservices = new ContactUsServices(contactusservices.Object);
        }

        [Fact]
        public void TestFor_ValidInputs()
        {
            Buyer buyer = new Buyer()
            {
                 BuyerId = 1,
                FirstName = "ddd",
                LastName = "ddd",
                Email = "ff@gmail.com",
                PhoneNumber = 123456779,
                Address = "Delhi"
            };

          
            Assert.NotNull(buyer.FirstName);
            Assert.NotNull(buyer.Email);
            Assert.NotNull(buyer.Password);
        }
    }
}

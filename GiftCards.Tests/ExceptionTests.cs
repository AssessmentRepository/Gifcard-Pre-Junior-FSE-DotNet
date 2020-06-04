using GiftCards.BusinessLayer.Interface;
using GiftCards.BusinessLayer.Repository;
using GiftCards.BusinessLayer.Services;
using GiftCards.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GiftCards.Tests
{
   public class ExceptionTests
    {
        private IViewOrderServices _viworderservices;
        private IContactUsServices _contactusservices;
        private IBuyerServices _buyerservices;

        public readonly Mock<IBuyerRepository> buyerservice = new Mock<IBuyerRepository>();
        public readonly Mock<IViewOrderRepository> viworderservices = new Mock<IViewOrderRepository>();
        public readonly Mock<IContactUsRepository> contactusservices = new Mock<IContactUsRepository>();

        static ExceptionTests()
        {
            if (!File.Exists("../../../../output_exception_revised.txt"))
                try
                {
                    File.Create("../../../../output_exception_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_exception_revised.txt");
                File.Create("../../../../output_exception_revised.txt").Dispose();
            }
        }

        public ExceptionTests()
        {
            _buyerservices = new BuyerServices(buyerservice.Object);
            _viworderservices = new ViewOrderServices(viworderservices.Object);
            _contactusservices = new ContactUsServices(contactusservices.Object);
        }
        Random random = new Random();

        [Fact]
        public async Task ExceptionTestFor_UserNotFound()
        {
            try
            {
                //Arrange
                Buyer buyer = new Buyer()
                {
                    BuyerId = 100,
                    FirstName = "ddd",
                    LastName = "ddd",
                    Email = "ff@gmail.com",
                    PhoneNumber = 123456779,
                    Address = "Delhi"
                };

                Boolean getbuyer = await _buyerservices.GetBuyerByIdAsync(buyer.BuyerId);
                File.AppendAllText("../../../../output_exception_revised.txt", "ExceptionTestFor_UserNotFound=" + getbuyer.ToString() + "\n");

               // await Assert.ThrowsAsync<Exception>(async () => await _buyerservices.GetBuyerByIdAsync(buyer.BuyerId));
            }catch(Exception)
            {
                File.AppendAllText("../../../../output_exception_revised.txt", "ExceptionTestFor_UserNotFound= False\n");
            }
        }

        [Fact]
        public async Task ExceptionTest_Failure_BuyerRegistration()
        {
            try
          {
                //Arrange
                Buyer buyer = null;

                Boolean register = await _buyerservices.RegisterAsync(buyer);
                File.AppendAllText("../../../../output_exception_revised.txt", "ExceptionTest_Failure_BuyerRegistration=" + register.ToString() + "\n");

             //   await Assert.ThrowsAsync<ArgumentNullException>(async () => await _buyerservices.RegisterAsync(buyer));

            }catch(Exception)
            {
                File.AppendAllText("../../../../output_exception_revised.txt", "ExceptionTest_Failure_BuyerRegistration= False\n");
            }
        }

        [Fact]
        public async Task ExceptionTest_Failure_ContactUs()
        {
            try { 
            //Arrange
            ContactUs contact = null;
                //Act
                Boolean register = await _contactusservices.ContactUs(contact);
            File.AppendAllText("../../../../output_exception_revised.txt", "ExceptionTest_Failure_ContactUs=" + register.ToString() + "\n");
            //Assert
         //   await Assert.ThrowsAsync<ArgumentNullException>(async () => await _contactusservices.ContactUs(contact));
            }catch(Exception)
            {
                File.AppendAllText("../../../../output_exception_revised.txt", "ExceptionTest_Failure_ContactUs= False\n");
            }
        }
    }
}

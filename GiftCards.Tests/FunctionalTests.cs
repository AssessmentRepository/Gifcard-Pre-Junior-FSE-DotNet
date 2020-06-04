using GiftCards.BusinessLayer.Interface;
using GiftCards.BusinessLayer.Repository;
using GiftCards.BusinessLayer.Services;
using GiftCards.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace GiftCards.Tests
{
 public   class FunctionalTests
    {
        private IViewOrderServices _viworderservices;
        private IContactUsServices _contactusservices;
        private IBuyerServices _buyerservices;

        public readonly Mock<IBuyerRepository> buyerservice = new Mock<IBuyerRepository>();
        public readonly Mock<IViewOrderRepository> viworderservices = new Mock<IViewOrderRepository>();
        public readonly Mock<IContactUsRepository> contactusservices = new Mock<IContactUsRepository>();
        Buyer buyer;
        Gift gift;
        GiftOrder order;
        ContactUs contact;
        List<GiftOrder> orderList;
        List<Buyer> buyerlist;
        Random random = new Random();

        static FunctionalTests()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }

        public FunctionalTests()
        {
            _buyerservices = new BuyerServices(buyerservice.Object);
            _viworderservices = new ViewOrderServices(viworderservices.Object);
            _contactusservices = new ContactUsServices(contactusservices.Object);
            buyer = new Buyer()
            {
                BuyerId = random.Next(1, 300000),
                FirstName = "ddd",
                LastName = "ddd",
                Email = "ff@gmail.com",
                PhoneNumber = 123456779,
                Address = "Delhi"
            };
            gift = new Gift
            {
                  GiftId= random.Next(1, 300000),
                GiftName="giftFlower",
             Ammount=2000
              };
            order = new GiftOrder()
            {
                GiftOrderId = random.Next(1, 300000),
                RecepientName = "recepient",
                ShippingAddress = "Bangalore",
                GiftId = gift.GiftId,
                BuyerId = buyer.BuyerId
            };
             contact = new ContactUs()
            {
                ContactUsId = random.Next(1, 300),
                Name = "ContactUs",
                PhoneNumber = 9980765432,
                Email = "contact@gmail.com",
                Address = "bangalore"
            };
            orderList = new List<GiftOrder>();
            orderList.Add(order);
            buyerlist = new List<Buyer>();
            buyerlist.Add(buyer);
        }


        [Fact]
        public async Task TestFor_PlaceGiftCardOrder()
        {
            try
            {
                //Action
                var placeorder = await _buyerservices.PlaceGiftOrderAsync(order);
                File.AppendAllText("../../../../output_revised.txt", "TestFor_PlaceGiftCardOrder=" + placeorder.ToString() + "\n");

                //Assert
                Assert.True(placeorder);
            }catch(Exception)
            {
                File.AppendAllText("../../../../output_revised.txt", "TestFor_PlaceGiftCardOrder= False\n");
            }
        }


        [Fact]
        public async Task TestFor_AddContactUsDetails()
        {
            try
            {
                var contactus = await _contactusservices.ContactUs(contact);
                File.AppendAllText("../../../../output_revised.txt", "TestFor_AddContactUsDetails=" + contactus.ToString() + "\n");

                Assert.True(contactus);
            }catch(Exception)
            {
                File.AppendAllText("../../../../output_revised.txt", "TestFor_AddContactUsDetails= False\n");
            }
        }


        [Fact]
        public async Task TestFor_ViewAllGiftCards()
        {
            try
            {
                //Action
                viworderservices.Setup(repos => repos.ViewAllGiftCardOrders()).ReturnsAsync(orderList);
                var viewlist = await _viworderservices.ViewAllGiftCardOrders();
                int view = viewlist.Count();
                bool viewgift = Convert.ToBoolean(view);
                
                //Assert
                if (view > 0)
                {
                    File.AppendAllText("../../../../output_revised.txt", "TestFor_ViewAllGiftCards=" + viewgift.ToString() + "\n");
                }
                else
                {
                    File.AppendAllText("../../../../output_revised.txt", "TestFor_ViewAllGiftCards= False\n");
                }
            }catch(Exception)
            {
                File.AppendAllText("../../../../output_revised.txt", "TestFor_ViewAllGiftCards= False\n");
            }
        }

        [Fact]
        public async Task TestFor_BuyerRegistration()
        {
          try  {
                //Action
                var registeredBuyer = await _buyerservices.RegisterAsync(buyer);
                var getBuyer = await _buyerservices.GetBuyerByIdAsync(buyer.BuyerId);
                File.AppendAllText("../../../../output_revised.txt", "TestFor_BuyerRegistration=" + registeredBuyer.ToString() + "\n");


                //Assert
                Assert.True( registeredBuyer);
                Assert.Equal(getBuyer, registeredBuyer);
            }catch(Exception)
            {
                File.AppendAllText("../../../../output_revised.txt", "TestFor_BuyerRegistration= False\n");
            }
        }


        [Fact]
        public async Task TestFor_BuyerLogin()
        {
            try{
                //Action
               
                var registeredBuyer = await _buyerservices.Login(buyer);
                var getBuyer = await _buyerservices.GetBuyerByIdAsync(buyer.BuyerId);
                File.AppendAllText("../../../../output_revised.txt", "TestFor_BuyerLogin=" + registeredBuyer.ToString() + "\n");

                //Assert
                Assert.True( registeredBuyer);
                Assert.Equal(getBuyer, registeredBuyer);
            }catch(Exception)
            {
                File.AppendAllText("../../../../output_revised.txt", "TestFor_BuyerLogin= False\n");
            }
        }
        [Fact]
        public async Task TestFor_BuyerLogOut()
        {
           try {
                //Action
                buyerservice.Setup(repos => repos.LogOut(buyer)).ReturnsAsync(true);
                var isLoggedOut = await _buyerservices.LogOut(buyer);
                File.AppendAllText("../../../../output_revised.txt", "TestFor_BuyerLogOut=" + isLoggedOut.ToString() + "\n");

                //Assert
                Assert.True(isLoggedOut);
            }
            catch(Exception)
            {
                File.AppendAllText("../../../../output_revised.txt", "TestFor_BuyerLogOut= False\n");
            }
        }
        [Fact]
        public async Task TestFor_GetBuyerById()
        {
           try {
                //Action
         
                var getBuyer = await _buyerservices.GetBuyerByIdAsync(buyer.BuyerId);

                File.AppendAllText("../../../../output_revised.txt", "TestFor_GetBuyerById=" + getBuyer.ToString() + "\n");

                //Assert
                Assert.True(getBuyer);

            }
            catch (Exception)
            {
                File.AppendAllText("../../../../output_revised.txt", "TestFor_GetBuyerById= False\n");
            }
        }
        [Fact]
        public async Task TestFor_GetAllBuyers()
        {
           try {
                //Action
                buyerservice.Setup(repos => repos.GetAllBuyersAsync()).ReturnsAsync(buyerlist);
                var getBuyerList = await _buyerservices.GetAllBuyersAsync();
               int getall = getBuyerList.Count();
                var allbuyer = Convert.ToBoolean(getall);
              //  File.AppendAllText("../../../../output_revised.txt", "TestFor_GetAllBuyers=" + allbuyer.ToString() + "\n");

                //Assert
                if(getall>0)
                {
                    File.AppendAllText("../../../../output_revised.txt", "TestFor_GetAllBuyers=" + allbuyer.ToString() + "\n");
                }
                else
                {
                    File.AppendAllText("../../../../output_revised.txt", "TestFor_GetAllBuyers= False\n");
                }
            }catch(Exception)
            {
                File.AppendAllText("../../../../output_revised.txt", "TestFor_GetAllBuyers= False\n");
            }
        }
        

        [Fact]
        public async Task TestFor_DeleteContactUsDetails()
        {
            try
            {
                //Action
                contactusservices.Setup(repos => repos.DeleteContactUs(contact.ContactUsId)).ReturnsAsync(true);
                var isDeleted = await _contactusservices.DeleteContactUs(contact.ContactUsId);
                File.AppendAllText("../../../../output_revised.txt", "TestFor_DeleteContactUsDetails=" + isDeleted.ToString() + "\n");

                //Assert
                Assert.True(isDeleted);
            }
            catch (Exception)
            {
                File.AppendAllText("../../../../output_revised.txt", "TestFor_DeleteContactUsDetails= False\n");
            }   
        }
        [Fact]
        public async Task TestFor_UpdateContactUsDetails()
        {
           try {
                //Action
                
                var getcontact = await _contactusservices.UpdateContactUs(contact.ContactUsId);
                File.AppendAllText("../../../../output_revised.txt", "TestFor_UpdateContactUsDetails=" + getcontact.ToString() + "\n");

                //Assert
                Assert.True( getcontact);
            }catch(Exception)
            {
                File.AppendAllText("../../../../output_revised.txt", "TestFor_UpdateContactUsDetails= False\n");
            }
        }
    }
}

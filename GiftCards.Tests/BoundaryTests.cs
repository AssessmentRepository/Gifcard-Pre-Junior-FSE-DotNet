using GiftCards.BusinessLayer.Interface;
using GiftCards.BusinessLayer.Repository;
using GiftCards.BusinessLayer.Services;
using GiftCards.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace GiftCards.Tests
{
   public class BoundaryTests
    {
        private IViewOrderServices _viworderservices;
        private IContactUsServices _contactusservices;
        private IBuyerServices _buyerservices;

        public readonly Mock<IBuyerRepository> buyerservice = new Mock<IBuyerRepository>();
        public readonly Mock<IViewOrderRepository> viworderservices = new Mock<IViewOrderRepository>();
        public readonly Mock<IContactUsRepository> contactusservices = new Mock<IContactUsRepository>();

        static BoundaryTests()
        {
            if (!File.Exists("../../../../output_boundary_revised.txt"))
                try
                {
                    File.Create("../../../../output_boundary_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_boundary_revised.txt");
                File.Create("../../../../output_boundary_revised.txt").Dispose();
            }
        }

        public BoundaryTests()
        {
            _buyerservices = new BuyerServices(buyerservice.Object);
            _viworderservices = new ViewOrderServices(viworderservices.Object);
            _contactusservices = new ContactUsServices(contactusservices.Object);
        }
        Random random = new Random();

        [Fact]
        public async Task BoundaryTestFor_ValidBuyerIdAsync()
        {
            try
            {
                //Action
                Buyer buyer = new Buyer()
                {
                    BuyerId = random.Next(1, 300000),
                    FirstName = "Buyer",
                    LastName = "user",
                    Email = "user@gmail.com",
                    Password = "password",
                    PhoneNumber = 9087654321,
                    Address = "Delhi",
                    Pincode = 678490,
                };
                var MinValue = 1;
                var MaxValue = 300000;


                if (buyer.BuyerId < MaxValue && buyer.BuyerId > MinValue)
                {
                    Boolean id = await _buyerservices.RegisterAsync(buyer);
                    File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestFor_ValidBuyerId=" + id.ToString() + "\n");
                    
                }
                else
                {
                    File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestFor_ValidBuyerId= False\n");
                  
                }
            }
            catch(Exception)
            {
                File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestFor_ValidBuyerId= False\n");
                
            }

        }

        [Fact]
        public async Task BoundaryTestFor_ValidPasswordLengthAsync()
        {
            try
            {
                //Arrange
                Buyer buyer = new Buyer()
                {
                    BuyerId = random.Next(1, 300000),
                    FirstName = "Buyer",
                    LastName = "user",
                    Email = "user@gmail.com",
                    Password = "password",
                    PhoneNumber = 9087654321,
                    Address = "Delhi",
                    Pincode = 678490,
                };
                var MinValue = 8;
                var MaxValue = 20;

                if (buyer.Password.Length < MaxValue && buyer.Password.Length > MinValue)
                {
                    Boolean getbuyer = await _buyerservices.GetBuyerByIdAsync(buyer.BuyerId);

                    File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestFor_ValidPasswordLengthAsync=" + getbuyer.ToString() + "\n");
                }
                else
                {
                    File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestFor_ValidPasswordLengthAsync= False\n");
                }
            }
            catch (Exception)
            {
                File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestFor_ValidPasswordLengthAsync= False\n");
            }
        }

        [Fact]
        public async Task BoundaryTestFor_ValidBuyerEmailAsync()
        {
            try
            {
                //Action
                Buyer buyer = new Buyer()
                {
                    BuyerId = random.Next(1, 300000),
                    FirstName = "Buyer",
                    LastName = "user",
                    Email = "user@gmail.com",
                    Password = "password",
                    PhoneNumber = 9087654321,
                    Address = "Delhi",
                    Pincode = 678490
                };
                //Action
                Boolean getbuyer = await _buyerservices.GetBuyerByIdAsync(buyer.BuyerId);

                bool isEmail = Regex.IsMatch(buyer.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestFor_ValidBuyerEmailAsync=" + isEmail.ToString() + "\n");

                //Assert
                Assert.True(isEmail);
            }
            catch(Exception)
            {
                File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestFor_ValidBuyerEmailAsync= False\n");
            }
        }
    }
}

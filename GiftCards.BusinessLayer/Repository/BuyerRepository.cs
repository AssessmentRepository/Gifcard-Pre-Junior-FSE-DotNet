using Dapper;
using GiftCards.DataLayer;
using GiftCards.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiftCards.BusinessLayer.Repository
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public BuyerRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;

        }

        public async Task<bool> Register(Buyer Buyer)
        {
            try
            {
                var connection = await _dbConnectionFactory.CreateConnectionAsync();
                await _dbConnectionFactory.SetupAsync();
                await connection.ExecuteAsync("Insert into Buyer (BuyerId, FirstName, LastName, phoneNumber, Email,Password, Address,Pincode) VALUES (@buyerId, @firstName,@lastName,@phoneNumber,@email,@password,@address,@pincode)", new { buyerId = Buyer.BuyerId, firstName = Buyer.FirstName, lastName = Buyer.LastName, phoneNumber = Buyer.PhoneNumber, email = Buyer.Email,password=Buyer.Password, address = Buyer.Address,pincode=Buyer.Pincode });
                if(Buyer!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<IEnumerable<Buyer>> GetAllBuyersAsync()
        {
            try
            {
                var connection = await _dbConnectionFactory.CreateConnectionAsync();
                await _dbConnectionFactory.SetupAsync();
                return await connection.QueryAsync<Buyer>("select * from Buyer");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Task<bool> ChangePassword(int BuyerID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Login(Buyer buyer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogOut(Buyer buyer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PlaceGiftOrderAsync(GiftOrder Order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetBuyerByIdAsync(int BuyerId)
        {
            throw new NotImplementedException();
        }
    }
}

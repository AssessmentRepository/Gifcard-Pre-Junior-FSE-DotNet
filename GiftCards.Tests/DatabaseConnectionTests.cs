using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GiftCards.Tests
{
  public  class DatabaseConnectionTests
    {
        string _dbLocation = "./giftcards.db";

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqliteConnection($"Data Source={_dbLocation}");
            await connection.OpenAsync();
            return connection;
        }

        [Fact]
        public void TestFor_DatabaseConnection()
        {
            var connection = CreateConnectionAsync();
            Assert.NotNull(connection);
        }
    }
}

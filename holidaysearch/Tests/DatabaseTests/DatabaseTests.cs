using System.Linq;
using HolidaySearch.Configuration;
using HolidaySearch.Database;
using HolidaySearch.Interfaces;
using HolidaySearch.Models;
using LiteDB;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace HolidaySearch.Tests.DatabaseTests
{
    public class LiteDbContextTests
    {
        private readonly ISeedDataReader _seedDataReader;
        private readonly Mock<IOptions<LiteDbOptions>> _mockOptions;
        private readonly LiteDbOptions _liteDbOptions;

        public LiteDbContextTests()
        {
            _seedDataReader = new SeedDataReader();
            _mockOptions = new Mock<IOptions<LiteDbOptions>>();
            _liteDbOptions = new LiteDbOptions
            {
                DatabaseLocation = ":memory:",
                FlightDataFilePath = "./Database/SeedData/flights.json",
                HotelDataFilePath = "./Database/SeedData/hotels.json",
                FlightCollection = "flights",
                HotelCollection = "hotels"
            };

            _mockOptions.Setup(o => o.Value).Returns(_liteDbOptions);
        }

        [Fact]
        public void LiteDbContext_DatabaseIsCreated()
        {
            // Arrange
            var context = new LiteDbContext(_seedDataReader, _mockOptions.Object);

            // Act
            var database = context.Database;

            // Assert
            Assert.NotNull(database);
        }

    }
}
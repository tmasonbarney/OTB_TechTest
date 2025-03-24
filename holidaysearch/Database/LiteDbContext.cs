using HolidaySearch.Configuration;
using HolidaySearch.Interfaces;
using HolidaySearch.Models;
using LiteDB;
using Microsoft.Extensions.Options;

public class LiteDbContext : ILiteDbContext
{
     private readonly ISeedDataReader _seedDataReader;
    private readonly IOptions<LiteDbOptions> _options;
    public LiteDatabase Database { get; }
   

    public LiteDbContext(ISeedDataReader seedDataReader, IOptions<LiteDbOptions> options)
    {
        Database = new LiteDatabase(options.Value.DatabaseLocation);
        _options = options;
        _seedDataReader = seedDataReader;
        SeedDatabase();
    }

    private void SeedDatabase() {
         // Seed the database with the data from the json files   
        _seedDataReader.ReadData<Flight>(_options.Value.FlightDataFilePath)
            .ForEach(flight => Database.GetCollection<Flight>(_options.Value.FlightCollection).Insert(flight));

        // Seed the database with the data from the json files
        _seedDataReader.ReadData<Hotel>(_options.Value.HotelDataFilePath)
            .ForEach(hotel => Database.GetCollection<Hotel>(_options.Value.FlightCollection).Insert(hotel));
    }
}
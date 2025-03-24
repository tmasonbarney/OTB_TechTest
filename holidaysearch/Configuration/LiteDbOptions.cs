namespace HolidaySearch.Configuration
{
    public class LiteDbOptions
    {
        public string DatabaseLocation { get; set; }
        public string FlightDataFilePath { get; set; }
        public string HotelDataFilePath { get; set; }
        public string FlightCollection { get; set; }
        public string HotelCollection { get; set; }
    }
}
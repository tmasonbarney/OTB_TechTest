using System.Text.Json;
using HolidaySearch.Models;
using HolidaySearch.Interfaces;
using System.Collections.Generic;

namespace HolidaySearch.Database
{
    public class SeedDataReader : ISeedDataReader 
    {
        public List<T> ReadData<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
        }
    }
}
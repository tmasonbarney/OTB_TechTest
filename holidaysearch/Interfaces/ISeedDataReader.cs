
using HolidaySearch.Models;

namespace HolidaySearch.Interfaces
{
public interface ISeedDataReader
    {
        List<T> ReadData<T>(string filePath);
    }

}
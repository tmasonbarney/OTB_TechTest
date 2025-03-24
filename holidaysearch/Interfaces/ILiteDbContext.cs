
using LiteDB;

namespace HolidaySearch.Interfaces
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }

}
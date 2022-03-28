using System.Data.SQLite;

namespace currency_converter.Adapters.DataRead
{
    public class BaseRepository
    {
        public static SQLiteConnection DbConnection()
        {
            return new SQLiteConnection("Data Source=CurrencyConverter.db");
        }
    }
}

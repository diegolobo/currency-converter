using currency_converter.Adapters.DataRead.Queries;
using currency_converter.Modules.Domain.Entities;
using Dapper;
using System.Linq;

namespace currency_converter.Adapters.DataRead
{
    public class CurrencyReadRepository : BaseRepository
    {
        public double GetConvertedAmount(string from, string to, double amount)
        {
            using (var connection = DbConnection())
            {
                connection.Open();
                double? rate = connection.Query<double>(CurrencyQueries.GetConvertedAmount, new { from, to }).FirstOrDefault();

                if (rate == null)
                    return 0;

                return (double)rate * amount;
            }
        }

        public Currency GetCurrency(string code)
        {
            using (var connection = DbConnection())
            {
                connection.Open();
                return connection.Query<Currency>(CurrencyQueries.GetCurrency, new { code }).FirstOrDefault();
            }
        }
    }
}

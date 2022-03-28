using currency_converter.Adapters.DataAccess.Contexts;
using currency_converter.Modules.Domain.Entities;
using currency_converter.Modules.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace currency_converter.Adapters.DataAccess.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly SqliteContext _context;

        public RateRepository(SqliteContext context)
        {
            _context = context;
        }

        public bool RateExists(string code, int currencyId)
        {
            return _context.Rate.Any(r => r.Code.Equals(code) && r.CurrencyId.Equals(currencyId));
        }

        public void Create(Rate rate)
        {
            _context.Rate.Add(rate);
            _context.SaveChanges();
        }

        public void Update(Rate rate)
        {
            var dbRate = _context.Rate.Where(x => x.Id == rate.Id).SingleOrDefault();

            if (dbRate != null)
            {
                rate.InsertDate = dbRate.InsertDate;

                _context.Entry(dbRate).CurrentValues.SetValues(rate);
                _context.Entry(dbRate).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var dbRate = _context.Rate.Where(x => x.Id == id).SingleOrDefault();

            if (dbRate != null)
            {
                dbRate.Active = false;
                _context.Entry(dbRate).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}

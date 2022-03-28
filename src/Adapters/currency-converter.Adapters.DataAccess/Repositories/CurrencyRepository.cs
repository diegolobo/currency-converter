using currency_converter.Adapters.DataAccess.Contexts;
using currency_converter.Modules.Domain.Entities;
using currency_converter.Modules.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace currency_converter.Adapters.DataAccess.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly SqliteContext _context;

        public CurrencyRepository(SqliteContext context)
        {
            _context = context;
        }

        public List<Currency> GetAll()
        {
            return _context.Currency.Where(c => c.Active).ToList();
        }

        public Currency GetByCode(string code)
        {
            return _context.Currency.FirstOrDefault(c => c.Code.Equals(code));
        }

        public bool CodeExists(string code)
        {
            return _context.Currency.Any(c => c.Code.Equals(code));
        }

        public void Create(Currency currency)
        {
            _context.Currency.Add(currency);
            _context.SaveChanges();
        }

        public void Update(Currency currency)
        {
            var dbCurrency = _context.Currency.Where(x => x.Id == currency.Id).SingleOrDefault();

            if (dbCurrency != null)
            {
                currency.InsertDate = dbCurrency.InsertDate;

                _context.Entry(dbCurrency).CurrentValues.SetValues(currency);
                _context.Entry(dbCurrency).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var dbCurrency = _context.Currency.Where(x => x.Id == id).SingleOrDefault();

            if (dbCurrency != null)
            {
                dbCurrency.Active = false;                
                _context.Entry(dbCurrency).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}

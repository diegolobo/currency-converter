using currency_converter.Modules.Domain.Entities;
using System.Collections.Generic;

namespace currency_converter.Modules.Domain.Repositories
{
    public interface ICurrencyRepository
    {
        List<Currency> GetAll();

        Currency GetByCode(string code);

        bool CodeExists(string code);

        void Create(Currency currency);

        void Update(Currency currency);

        void Delete(long id);
    }
}

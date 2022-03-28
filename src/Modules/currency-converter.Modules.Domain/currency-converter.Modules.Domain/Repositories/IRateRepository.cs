using currency_converter.Modules.Domain.Entities;

namespace currency_converter.Modules.Domain.Repositories
{
    public interface IRateRepository
    {
        bool RateExists(string code, int currencyId);

        void Create(Rate rate);

        void Update(Rate rate);

        void Delete(long id);
    }
}

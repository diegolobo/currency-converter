using currency_converter.Modules.Domain.Entities;
using System.Threading.Tasks;

namespace currency_converter.Modules.Domain.Services
{
    public interface IRateService
    {
        public Task<Rate> GetRate(string from, string to);
    }
}

using currency_converter.Modules.Domain.Commands.Currency;
using System.Threading.Tasks;

namespace currency_converter.Modules.Domain.Handlers
{
    public interface ICurrencyHandler : IHandler<CreateCurrencyCommand>,
                                        IHandler<UpdateCurrencyCommand>,
                                        IHandler<DeleteCurrencyCommand>
    {
        Task ImportCurrencies();
    }
}

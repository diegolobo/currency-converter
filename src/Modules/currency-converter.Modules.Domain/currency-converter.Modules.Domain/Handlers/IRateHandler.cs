using currency_converter.Modules.Domain.Commands.Rate;
using System.Threading.Tasks;

namespace currency_converter.Modules.Domain.Handlers
{
    public interface IRateHandler : IHandler<CreateRateCommand>,
                                        IHandler<UpdateRateCommand>,
                                        IHandler<DeleteRateCommand>
    {
        Task ImportRates();
    }
}

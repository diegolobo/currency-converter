using currency_converter.Modules.Domain.Commands;

namespace currency_converter.Modules.Domain.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        CommandResult Handle(T command);
    }
}

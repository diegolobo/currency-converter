using currency_converter.Modules.Domain.Utils;
using E = currency_converter.Modules.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace currency_converter.Modules.Domain.Commands.Currency
{
    public class UpdateCurrencyCommand : Notifiable, ICommand
    {
        #region Constructors

        public UpdateCurrencyCommand()
        {

        }

        #endregion

        #region Properties

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        #endregion

        #region Methods

        public bool IsValid()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Id, nameof(Id), DomainConstants.GET_NOT_NULL_MESSAGE(nameof(Id)))
                    .IsNotNullOrWhiteSpace(Code, Code, DomainConstants.GET_NOT_NULL_MESSAGE(nameof(Code)))
                    .HasLen(Code, E.Currency.CODE_SIZE, Code, DomainConstants.GET_MIN_VALUE_MESSAGE(nameof(Code), E.Currency.CODE_SIZE))
                    .IsNotNullOrWhiteSpace(Name, Name, DomainConstants.GET_NOT_NULL_MESSAGE(nameof(Name)))
                    .HasMinLen(Name, E.Currency.NAME_MIN_SIZE, Name, DomainConstants.GET_MIN_VALUE_MESSAGE(nameof(Name), E.Currency.NAME_MIN_SIZE))
                    .HasMaxLen(Name, E.Currency.NAME_MAX_SIZE, Name, DomainConstants.GET_MAX_VALUE_MESSAGE(nameof(Name), E.Currency.NAME_MAX_SIZE))
            );

            return Valid;
        }

        #endregion
    }
}

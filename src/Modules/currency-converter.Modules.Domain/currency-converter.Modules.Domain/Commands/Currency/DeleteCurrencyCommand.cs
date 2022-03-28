﻿using currency_converter.Modules.Domain.Utils;
using Flunt.Notifications;
using Flunt.Validations;

namespace currency_converter.Modules.Domain.Commands.Currency
{
    public class DeleteCurrencyCommand : Notifiable, ICommand
    {
        #region Constructors

        public DeleteCurrencyCommand()
        {

        }

        #endregion

        #region Properties

        public int Id { get; set; }

        #endregion

        #region Methods

        public bool IsValid()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Id, nameof(Id), DomainConstants.GET_NOT_NULL_MESSAGE(nameof(Id)))
            );

            return Valid;
        }

        #endregion
    }
}

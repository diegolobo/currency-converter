﻿using currency_converter.Modules.Domain.Utils;
using E = currency_converter.Modules.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace currency_converter.Modules.Domain.Commands.Rate
{
    public class UpdateRateCommand : Notifiable, ICommand
    {
        #region Constructors

        public UpdateRateCommand()
        {

        }

        #endregion

        #region Properties

        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public string Code { get; set; }
        public double Value { get; set; }

        #endregion

        #region Methods

        public bool IsValid()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(nameof(Id), 0, nameof(Id), DomainConstants.GET_NOT_NULL_MESSAGE(nameof(Id)))
                    .IsNotNullOrWhiteSpace(Code, Code, DomainConstants.GET_NOT_NULL_MESSAGE(nameof(Code)))
                    .HasLen(Code, E.Currency.CODE_SIZE, Code, DomainConstants.GET_MIN_VALUE_MESSAGE(nameof(Code), E.Currency.CODE_SIZE))
                    .HasMinLen(nameof(Value), 0, nameof(Value), DomainConstants.GET_MIN_VALUE_MESSAGE(nameof(Value), 0))
                    .HasMinLen(nameof(CurrencyId), 0, nameof(CurrencyId), DomainConstants.GET_MIN_VALUE_MESSAGE(nameof(CurrencyId), 0))
            );

            return Valid;
        }

        #endregion
    }
}

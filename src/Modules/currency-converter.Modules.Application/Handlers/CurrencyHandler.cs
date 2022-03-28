using AutoMapper;
using currency_converter.Modules.Domain.Commands;
using currency_converter.Modules.Domain.Commands.Currency;
using currency_converter.Modules.Domain.Entities;
using currency_converter.Modules.Domain.Handlers;
using currency_converter.Modules.Domain.Repositories;
using currency_converter.Modules.Domain.Services;
using currency_converter.Modules.Domain.Utils;
using System;
using System.Threading.Tasks;

namespace currency_converter.Modules.Application.Handlers
{
    public class CurrencyHandler : ICurrencyHandler
    {
        private readonly ICurrencyService _service;
        private readonly ICurrencyRepository _repository;
        private readonly IMapper _mapper;

        public CurrencyHandler(ICurrencyService service, ICurrencyRepository repository, IMapper mapper)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        public CommandResult Handle(CreateCurrencyCommand command)
        {
            if (!command.IsValid())
                return new CommandResult(DomainConstants.DEFAULT_ERROR_MESSAGE, command.Notifications).SetFailResult();
            try
            {
                var currency = _mapper.Map<Currency>(command);
                _repository.Create(currency);

                return new CommandResult(DomainConstants.DEFAULT_SUCCESS_MESSAGE, currency).SetSuccessResult();
            }
            catch (Exception ex)
            {
                return new CommandResult(DomainConstants.DEFAULT_ERROR_MESSAGE, ex.Message).SetFailResult();
            }           
        }

        public CommandResult Handle(UpdateCurrencyCommand command)
        {
            if (!command.IsValid())
                return new CommandResult(DomainConstants.DEFAULT_ERROR_MESSAGE, command.Notifications).SetFailResult();
            try
            {
                var currency = _mapper.Map<Currency>(command);
                _repository.Update(currency);

                return new CommandResult(DomainConstants.DEFAULT_SUCCESS_MESSAGE, currency).SetSuccessResult();
            }
            catch (Exception ex)
            {
                return new CommandResult(DomainConstants.DEFAULT_ERROR_MESSAGE, ex.Message).SetFailResult();
            }
        }

        public CommandResult Handle(DeleteCurrencyCommand command)
        {
            if (!command.IsValid())
                return new CommandResult(DomainConstants.DEFAULT_ERROR_MESSAGE, command.Notifications).SetFailResult();
            try
            {
                _repository.Delete(command.Id);

                return new CommandResult(DomainConstants.DEFAULT_SUCCESS_MESSAGE, null).SetSuccessResult();
            }
            catch (Exception ex)
            {
                return new CommandResult(DomainConstants.DEFAULT_ERROR_MESSAGE, ex.Message).SetFailResult();
            }
        }

        public async Task ImportCurrencies()
        {
            try
            {
                var currencies = await _service.GetAvailableCurrencies();

                foreach (var currency in currencies)
                    if (!_repository.CodeExists(currency.Key))
                        _repository.Create(new Currency(currency.Key, currency.Value));
                 
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}

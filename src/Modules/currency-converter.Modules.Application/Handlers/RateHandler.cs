using AutoMapper;
using currency_converter.Modules.Domain.Commands;
using currency_converter.Modules.Domain.Commands.Rate;
using currency_converter.Modules.Domain.Entities;
using currency_converter.Modules.Domain.Handlers;
using currency_converter.Modules.Domain.Repositories;
using currency_converter.Modules.Domain.Services;
using currency_converter.Modules.Domain.Utils;
using System;
using System.Threading.Tasks;

namespace currency_converter.Modules.Application.Handlers
{
    public class RateHandler : IRateHandler
    {
        private readonly IRateService _service;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IRateRepository _repository;
        private readonly IMapper _mapper;

        public RateHandler(IRateService service, 
                           IRateRepository repository, 
                           ICurrencyRepository currencyRepository, 
                           IMapper mapper)
        {
            _service = service;
            _repository = repository;
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public CommandResult Handle(CreateRateCommand command)
        {
            if (!command.IsValid())
                return new CommandResult(DomainConstants.DEFAULT_ERROR_MESSAGE, command.Notifications).SetFailResult();
            try
            {
                var rate = _mapper.Map<Rate>(command);
                _repository.Create(rate);

                return new CommandResult(DomainConstants.DEFAULT_SUCCESS_MESSAGE, rate).SetSuccessResult();
            }
            catch (Exception ex)
            {
                return new CommandResult(DomainConstants.DEFAULT_ERROR_MESSAGE, ex.Message).SetFailResult();
            }           
        }

        public CommandResult Handle(UpdateRateCommand command)
        {
            if (!command.IsValid())
                return new CommandResult(DomainConstants.DEFAULT_ERROR_MESSAGE, command.Notifications).SetFailResult();
            try
            {
                var rate = _mapper.Map<Rate>(command);
                _repository.Update(rate);

                return new CommandResult(DomainConstants.DEFAULT_SUCCESS_MESSAGE, rate).SetSuccessResult();
            }
            catch (Exception ex)
            {
                return new CommandResult(DomainConstants.DEFAULT_ERROR_MESSAGE, ex.Message).SetFailResult();
            }
        }

        public CommandResult Handle(DeleteRateCommand command)
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

        public async Task ImportRates()
        {
            var currencies = _currencyRepository.GetAll();

            foreach (var currency in currencies)
            {
                foreach (var currencyAux in currencies)
                {
                    if (currency.Id == currencyAux.Id)
                        continue;

                    try
                    {
                        var rate = await _service.GetRate(currency.Code, currencyAux.Code);

                        if (!rate.Code.Equals("CoinNotExists") && !_repository.RateExists(rate.Code, currency.Id))
                        {
                            _repository.Create(new Rate
                            {
                                Active = true,
                                InsertDate = DateTime.Now,
                                CurrencyId = currency.Id,
                                Currency = currency,
                                Code = rate.Code,
                                Value = rate.Value
                            });
                        }
                    }
                    catch (Exception ex)
                    {

                    }                        
                }
            }
        }
    }
}

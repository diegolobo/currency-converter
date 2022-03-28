using AutoMapper;
using currency_converter.Adapters.Provider.DTO;
using currency_converter.Modules.Domain.Commands.Currency;
using currency_converter.Modules.Domain.Commands.Rate;
using currency_converter.Modules.Domain.Entities;

namespace currency_converter.Modules.Application.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Currency, CreateCurrencyCommand>()
                .ReverseMap()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForSourceMember(cc => cc.Invalid, opt => opt.DoNotValidate())
                .ForSourceMember(cc => cc.Valid, opt => opt.DoNotValidate())
                .ForSourceMember(cc => cc.Notifications, opt => opt.DoNotValidate());

            CreateMap<Currency, UpdateCurrencyCommand>()
                .ReverseMap()
                .ForMember(c => c.InsertDate, opt => opt.Ignore())
                .ForMember(c => c.Active, opt => opt.Ignore())
                .ForSourceMember(uc => uc.Invalid, opt => opt.DoNotValidate())
                .ForSourceMember(uc => uc.Valid, opt => opt.DoNotValidate())
                .ForSourceMember(uc => uc.Notifications, opt => opt.DoNotValidate());

            CreateMap<Rate, CreateRateCommand>()
                .ReverseMap()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForSourceMember(cc => cc.Invalid, opt => opt.DoNotValidate())
                .ForSourceMember(cc => cc.Valid, opt => opt.DoNotValidate())
                .ForSourceMember(cc => cc.Notifications, opt => opt.DoNotValidate());

            CreateMap<Rate, UpdateRateCommand>()
                .ReverseMap()
                .ForMember(c => c.InsertDate, opt => opt.Ignore())
                .ForMember(c => c.Active, opt => opt.Ignore())
                .ForSourceMember(uc => uc.Invalid, opt => opt.DoNotValidate())
                .ForSourceMember(uc => uc.Valid, opt => opt.DoNotValidate())
                .ForSourceMember(uc => uc.Notifications, opt => opt.DoNotValidate());

            CreateMap<Rate, RateDto>()
                .ReverseMap()
                .ForMember(r => r.Id, opt => opt.Ignore())
                .ForMember(r => r.Active, opt => opt.Ignore())
                .ForMember(r => r.Currency, opt => opt.Ignore())
                .ForMember(r => r.CurrencyId, opt => opt.Ignore())
                .ForMember(r => r.InsertDate, opt => opt.Ignore())
                .ForMember(r => r.Value, opt => opt.MapFrom(rd => SetDoubleValue(rd.Value)));   
        }

        private double SetDoubleValue(string value)
        {
            double.TryParse(value.Replace('.', ','), out double val);

            return val;
        }
    }
}

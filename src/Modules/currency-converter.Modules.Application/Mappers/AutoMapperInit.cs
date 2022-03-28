using AutoMapper;

namespace currency_converter.Modules.Application.Mappers
{
    public class AutoMapperInit
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            return config;
        }
    }
}

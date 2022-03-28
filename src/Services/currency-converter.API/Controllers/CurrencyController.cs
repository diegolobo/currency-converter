using currency_converter.Adapters.DataRead;
using currency_converter.Modules.Domain.Commands;
using currency_converter.Modules.Domain.Commands.Currency;
using currency_converter.Modules.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace currency_converter.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CurrencyController : ControllerBase
    {
        [HttpGet]
        [Route("{code}")]
        public ObjectResult GetByCode(
            [FromServices] CurrencyReadRepository repository,
            string code)
        {
            return Ok(repository.GetCurrency(code));
        }

        [HttpGet]
        [Route("convert/{amount}/{from}/{to}/")]
        public ObjectResult GetConvertedAmount(
            [FromServices] CurrencyReadRepository repository,
            double amount,
            string from, 
            string to)
        {
            return Ok(repository.GetConvertedAmount(from, to, amount));
        }

        [HttpPost]
        [Route("")]
        public ObjectResult Post(
            [FromServices] ICurrencyHandler hanlder,
            CreateCurrencyCommand command)
        {
            CommandResult result = hanlder.Handle(command);

            if(!result.Sucess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        [Route("")]
        public ObjectResult Put(
            [FromServices] ICurrencyHandler hanlder,
            UpdateCurrencyCommand command)
        {
            CommandResult result = hanlder.Handle(command);

            if (!result.Sucess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("")]
        public ObjectResult Delete(
            [FromServices] ICurrencyHandler hanlder,
            DeleteCurrencyCommand command)
        {
            CommandResult result = hanlder.Handle(command);

            if (!result.Sucess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

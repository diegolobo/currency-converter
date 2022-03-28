using currency_converter.Modules.Domain.Commands;
using currency_converter.Modules.Domain.Commands.Rate;
using currency_converter.Modules.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace currency_converter.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RateController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public ObjectResult Post(
            [FromServices] IRateHandler hanlder,
            CreateRateCommand command)
        {
            CommandResult result = hanlder.Handle(command);

            if(!result.Sucess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        [Route("")]
        public ObjectResult Put(
            [FromServices] IRateHandler hanlder,
            UpdateRateCommand command)
        {
            CommandResult result = hanlder.Handle(command);

            if (!result.Sucess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("")]
        public ObjectResult Delete(
            [FromServices] IRateHandler hanlder,
            DeleteRateCommand command)
        {
            CommandResult result = hanlder.Handle(command);

            if (!result.Sucess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

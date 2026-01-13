using ContractApp.Domain.Dtos.User;
using ContractApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContractApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/usuario")]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public IActionResult CriarConta([FromBody] UserCreateRequest request)
        {
            try
            {
                userService.CriarConta(request);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}

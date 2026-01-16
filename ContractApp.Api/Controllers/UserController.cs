using ContractApp.Domain.Dtos.User.Request;
using ContractApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContractApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController(IUserService userService) : ControllerBase
    {

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var user = userService.GetById(id);
                return StatusCode(200, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CriarConta([FromBody] UserCreateRequest request)
        {
            try
            {
                userService.CreateAccount(request);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpPost]
        [Route("auth")]
        public IActionResult Autenticar([FromBody] UserAuthenticateRequest request)
        {
            try
            {
                var user = userService.Auth(request);
                return StatusCode(200, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizarUsuario(int id, [FromBody] UserUpdateRequest request)
        {
            try
            {
                userService.UpdateUser(id, request);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

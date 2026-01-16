using ContractApp.Domain.Dtos.User.Request;
using ContractApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ContractApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController(IUserService userService) : ControllerBase
    {

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Retorna os dados de um usuário a partir de um id usuário")]
        public IActionResult GetBydId(int id)
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
        [SwaggerOperation(Summary = "Cria uma conta")]
        public IActionResult CriarConta([FromBody] UserCreateRequestDTO request)
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
        [SwaggerOperation(Summary = "Autentica através de e-mail e password")]
        public IActionResult Autenticar([FromBody] UserAuthenticateRequestDTO request)
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
        [SwaggerOperation(Summary = "Atualiza dados do usuário a partir de um id usuário")]
        public IActionResult Update(int id, [FromBody] UserUpdateRequestDTO request)
        {
            try
            {
                userService.Update(id, request);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}/update-password")]
        [SwaggerOperation(Summary = "Atualiza a senha do usuário a partir de um id usuário")]
        public IActionResult UpdatePassword(int userId, [FromBody] UserUpdatePasswordRequestDTO request)
        {
            try
            {
                userService.UpdatePassword(userId, request.PasswordOld, request.PasswordNew);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

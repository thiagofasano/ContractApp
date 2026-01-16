using ContractApp.Domain.Dtos.UserAddress.Request;
using ContractApp.Domain.Entities;
using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ContractApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/userAddress")]
    public class UserAddressController(IUserAddressService userAddressService) : ControllerBase
    {
        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Retorna os dados de endereço a partir de um id endereço")]
        public IActionResult GetById(int id) {
            try 
            {
                var response = userAddressService.GetById(id);
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("user/{userId:int}")]
        [SwaggerOperation(Summary = "Retorna os dados de endereço a partir de um id usuário")]
        public IActionResult GetByUserId(int userId)
        {
            try 
            {
                var response = userAddressService.GetByUserId(userId);
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Atualiza endereço a partir de um id endereço")]
        public IActionResult Update(int id, [FromBody] UserAddressRequestDTO address)
        {
            try
            {
                userAddressService.Update(id, address);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

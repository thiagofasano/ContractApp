using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContractApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/userAddress")]
    public class UserAddressController(IUserAddressService userAddressService) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetByUserId(int id)
        {
            try 
            {
                var response = userAddressService.GetAddressByUserId(id);
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}

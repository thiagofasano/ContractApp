using ContractApp.Domain.Dtos.Plan.Request;
using ContractApp.Domain.Dtos.Subscription.Request;
using ContractApp.Domain.Interfaces.Services;
using ContractApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ContractApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/subscription")]
    public class SubscriptionController(ISubscriptionService subscriptionService) : Controller
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Upgrade/Downgrade de um plano")]
        public IActionResult Adicionar([FromBody] SubscriptionUpDownGradeRequestDTO request)
        {
            try
            {
                subscriptionService.UpgradeDowngrade(request);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Busca subscription por id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var plan = subscriptionService.GetById(id);
                return Ok(plan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [HttpGet("user/{userId:int}")]
        [SwaggerOperation(Summary = "Busca subscription por id")]
        public IActionResult GetByUserId(int userId)
        {
            try
            {
                var plan = subscriptionService.GetByUserId(userId);
                return Ok(plan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

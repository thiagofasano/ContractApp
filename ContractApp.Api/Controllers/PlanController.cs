using ContractApp.Domain.Dtos.Plan.Request;
using ContractApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ContractApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/plan")]

    public class PlanController(IPlanService planService) : Controller
    {

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os planos")]
        public IActionResult GetAkk() {
            try
            {
                var plans = planService.GetAll();
                return Ok(plans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Lista plano por id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var plan = planService.GetById(id);
                return Ok(plan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Criar um plano")]
        public IActionResult Adicionar([FromBody] PlanRequestDTO request)
        {
            try
            {
                planService.Add(request);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Atualiza um plano")]
        public IActionResult Atualizar(int id, [FromBody] PlanRequestDTO request)
        {
            try
            {
                planService.Update(id, request);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }

}

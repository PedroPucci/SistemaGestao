using Microsoft.AspNetCore.Mvc;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
using SistemaGestãoColaboradoresUnidades.Service.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Api.Controllers
{
    [ApiController]
    [Route("api/v1/unities")]
    public class UnitiesController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public UnitiesController(IUnitOfWorkService serviceUoW)
        {
            _serviceUoW = serviceUoW;
        }


        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddUnityEntity([FromBody] UnityEntityDto unityEntityDto)
        {
            try
            {
                UnityEntity unityEntity = await _serviceUoW.UnityService.AddUnityEntity(unityEntityDto);
                return Ok(new
                {
                    mensagem = $"Unity registration completed successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error registering the unity! " + ex + ""
                });
            }
        }
    }
}
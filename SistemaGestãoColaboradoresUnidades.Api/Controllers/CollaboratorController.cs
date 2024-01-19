using Microsoft.AspNetCore.Mvc;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
using SistemaGestãoColaboradoresUnidades.Service.Service.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Api.Controllers
{
    [ApiController]
    [Route("api/v1/collaborator")]
    public class CollaboratorController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public CollaboratorController(IUnitOfWorkService serviceUoW)
        {
            _serviceUoW = serviceUoW;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddCollaboratoEntity([FromBody] CollaboratorDto collaboratorDto)
        {
            try
            {
                CollaboratorEntity collaboratorEntity = await _serviceUoW.CollaboratorService.AddCollaborator(collaboratorDto);
                return Ok(new
                {
                    mensagem = $"Collaborator registration completed successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error registering the Collaborator! " + ex + ""
                });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateCollaborator([FromBody] CollaboratorDto collaboratorDto)
        {
            try
            {
                CollaboratorEntity collaboratorEntity = await _serviceUoW.CollaboratorService.UpdateCollaborator(collaboratorDto);
                return Ok(new
                {
                    mensagem = $"Collaborator registration completed successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error registering the Collaborator! " + ex + ""
                });
            }
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCollaborators()
        {
            try
            {
                var colaboratorEntities = await _serviceUoW.CollaboratorService.GetAllCollaborators();
                return Ok(colaboratorEntities);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error loading collaborators! " + ex + ""
                });
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteCollaborator(int id)
        {
            try
            {
                CollaboratorEntity collaboratorEntity = await _serviceUoW.CollaboratorService.DeleteCollaborator(id);
                return Ok(new
                {
                    mensagem = $"Collaborator deleted completed successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error deleting the Collaborator! " + ex + ""
                });
            }
        }
    }
}
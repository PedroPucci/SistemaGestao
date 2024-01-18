using Microsoft.AspNetCore.Mvc;
using SistemaGestãoColaboradoresUnidades.Domain.Constant;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
using SistemaGestãoColaboradoresUnidades.Service.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Api.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersControllers : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public UsersControllers(IUnitOfWorkService serviceUoW)
        {
            _serviceUoW = serviceUoW;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddUserEntity([FromBody] UserEntityDto userEntityDto)
        {
            try
            {
                UserEntity userEntity = await _serviceUoW.UserService.AddUserEntity(userEntityDto);
                return Ok(new
                {
                    mensagem = $"User registration completed successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error registering the user! " + ex + ""
                });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateUserEntity([FromBody] UserEntityDto userEntityDto)
        {
            try
            {
                UserEntity? userEntity = await _serviceUoW.UserService.UpdateUserEntity(userEntityDto);
                return Ok(new
                {
                    mensagem = $"User registration updated successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "An error occurred while updating the user! " + ex + ""
                });
            }
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserEntityDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllUserEntities()
        {
            try
            {
                var userEntities = await _serviceUoW.UserService.GetAllUserEntities();
                return Ok(userEntities);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error loading users! " + ex + ""
                });
            }
        }

        [HttpGet("allUserEntityByStatus")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserEntityDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllUserEntityByStatus(StatusUser statusUser)
        {
            try
            {
                var userEntities = await _serviceUoW.UserService.GetAllUserEntityByStatus(statusUser);
                return Ok(userEntities);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error loading users! " + ex + ""
                });
            }
        }
    }
}
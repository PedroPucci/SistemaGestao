﻿using Microsoft.AspNetCore.Mvc;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
using SistemaGestãoColaboradoresUnidades.Service.Service.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Api.Controllers
{
    [ApiController]
    [Route("api/v1/unity")]
    public class UnityController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public UnityController(IUnitOfWorkService serviceUoW)
        {
            _serviceUoW = serviceUoW;
        }


        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddUnity([FromBody] UnityDto unityDto)
        {
            try
            {
                UnityEntity unityEntity = await _serviceUoW.UnityService.AddUnity(unityDto);
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateUnity([FromBody] UnityDto unityDto)
        {
            try
            {
                UnityEntity? unityEntity = await _serviceUoW.UnityService.UpdateUnity(unityDto);
                return Ok(new
                {
                    mensagem = $"Unity registration updated successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "An error occurred while updating the unity! " + ex + ""
                });
            }
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UnityDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllUnities()
        {
            try
            {
                var unityEntities = await _serviceUoW.UnityService.GetAllUnities();
                return Ok(unityEntities);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error loading unities! " + ex + ""
                });
            }
        }
    }
}
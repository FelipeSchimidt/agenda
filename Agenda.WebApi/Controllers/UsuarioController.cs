using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Agenda.Domain;
using Agenda.Repository;

namespace aspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IAgendaRepository repo { get; }
        public UsuarioController(IAgendaRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await repo.GetAllUsuarioAsync(true);

                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }
        }

        [HttpGet("{UsuarioId}")]
        public async Task<IActionResult> Get(int UsuarioId)
        {
            try
            {
                var results = await repo.GetUsuarioAsyncById(UsuarioId);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, "Erro no Banco de Dados");
            }
        }

        [HttpGet("getByName/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var results = await repo.GetAllUsuarioAsyncByName(name, true);

                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario model)
        {
            try
            {
                repo.Add(model);

                if (await repo.SaveChangeAsync())
                {
                    return Created($"/api/usuario/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int UsuarioId, Usuario model)
        {
            try
            {
                var usuario = await repo.GetUsuarioAsyncById(UsuarioId);

                if (usuario == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, "Usuário não encontrado");
                }

                repo.Update(model);

                if (await repo.SaveChangeAsync())
                {
                    return Created($"/api/usuario/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int UsuarioId)
        {
            try
            {
                var usuario = await repo.GetUsuarioAsyncById(UsuarioId);

                if (usuario == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, "Usuário não encontrado");
                }

                repo.Delete(usuario);

                if (await repo.SaveChangeAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }

            return BadRequest();
        }
    }
}
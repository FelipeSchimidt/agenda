using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Agenda.Repository;
using Agenda.Domain;

namespace aspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAgendaRepository repo;

        public LoginController(IAgendaRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet("{LoginId}")]
        public async Task<IActionResult> Get(int LoginId)
        {
            try
            {
                var results = await repo.GetLoginById(LoginId, true);

                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status404NotFound, "Login não encontrado");
            }
        }

        [HttpGet("getByName/{Nome}")]
        public async Task<IActionResult> Get(string Nome)
        {
            try
            {
                var results = await repo.GetLoginByName(Nome, true);

                if (results == null)
                {
                    return NotFound();
                }

                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status404NotFound, "Login não encontrado");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Login model)
        {
            try
            {
                repo.Add(model);

                if (await repo.SaveChangeAsync())
                {
                    return Created($"/api/login/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int LoginId, Login model)
        {
            try
            {
                var results = await repo.GetEventoById(LoginId, true);

                if (results == null)
                {
                    return NotFound();
                }

                repo.Update(model);

                if (await repo.SaveChangeAsync())
                {
                    return Created($"/api/login/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int EventoId)
        {
            try
            {
                var results = await repo.GetEventoById(EventoId, true);

                if (results == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, "Evento não encontrado");
                }

                repo.Delete(results);

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
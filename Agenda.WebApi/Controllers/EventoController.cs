using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Agenda.Domain;
using Agenda.Repository;
using System;

namespace aspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IAgendaRepository repo;

        public EventoController(IAgendaRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await repo.GetAllEventoAsync(true);

                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status404NotFound, "Evento não encontrado");
            }
        }

        [HttpGet("getByDate/{DataEvento}")]
        public async Task<IActionResult> Get(DateTime dataEvento)
        {
            try
            {
                var results = await repo.GetAllEventoByDataEvento(dataEvento, true);

                if (results == null)
                {
                    return NotFound();
                }

                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status404NotFound, "Evento não encontrado");
            }
        }

        [HttpGet("getByName/{Nome}")]
        public async Task<IActionResult> Get(string Nome)
        {
            try
            {
                var results = await repo.GetAllEventoByName(Nome, true);

                if (results == null)
                {
                    return NotFound();
                }

                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status404NotFound, "Evento não encontrado");
            }
        }

        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId)
        {
            try
            {
                var results = await repo.GetEventoById(EventoId, true);

                if (results == null)
                {
                    return NotFound();
                }

                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status404NotFound, "Evento não encontrado");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                repo.Add(model);

                if (await repo.SaveChangeAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int EventoId, Evento model)
        {
            try
            {
                var results = await repo.GetEventoById(EventoId, true);

                if (results == null)
                {
                    return NotFound();
                }

                repo.Update(model);

                if (await repo.SaveChangeAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
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
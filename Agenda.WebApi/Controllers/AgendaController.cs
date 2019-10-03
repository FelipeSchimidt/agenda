using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using aspApi.Models;
using aspApi.Database;

namespace aspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {

        private ApiDBContext context;

        public AgendaController(ApiDBContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAgendas()
        {
            try
            {
                var results = await context.Agendas.ToListAsync();

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, "Resultados não encontrado");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgenda(int id)
        {
            try
            {
                var results = await context.Agendas.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, "Resultados não encontrado");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAgenda(Agenda agenda)
        {
            var usuario = context.Usuarios.FirstAsync(x => x.Id == agenda.Users);
            if (usuario == null)
            {
                return NotFound();
            }
            var evento = context.Eventos.FirstAsync(x => x.Id == agenda.Events);
            if (evento == null)
            {
                return NotFound();
            }

            context.Agendas.Add(agenda);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgenda), agenda);
        }

    }
}
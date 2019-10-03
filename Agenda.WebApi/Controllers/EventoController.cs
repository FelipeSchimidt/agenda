using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using aspApi.Database;
using aspApi.Models;

namespace aspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private ApiDBContext context;

        public EventoController(ApiDBContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEvents()
        {
            return await context.Eventos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvent(int id)
        {
            var evento = await context.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }
            return evento;
        }

        [HttpPost]
        public async Task<ActionResult<Evento>> CreateEvent(Evento evento)
        {
            context.Eventos.Add(evento);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent),
                new { id = evento.Id },
                evento
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Evento>> UpdateEvent(int id, Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            context.Entry(evento).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Evento>> DeleteEvent(int id)
        {
            var evento = await context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            context.Remove(id);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
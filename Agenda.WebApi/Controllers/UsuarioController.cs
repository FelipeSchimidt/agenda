using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Agenda.Domain;

namespace aspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AgendaContext context;

        public UsuarioController(AgendaContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var users = await context.Usuarios.ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            try
            {
                var usuario = await context.Usuarios.FindAsync(id);

                return Ok(usuario);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, "Usuario não encontrado");
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();

            /** 
            * CreatedAtAction
            * 1º - Retorna STATUSCODE = 201 e adiciona ao Location a resposta
            * 2º - Refencia a ação GetUsuario
            * 3º - retorna usuário no qual usuario.include == id
            */
            return CreatedAtAction(nameof(GetUsuario),
                new { id = usuario.Id },
                usuario
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody]Usuario usuario)
        {
            try
            {
                /**
                * Especifica uma entitdade que tera seu estado alterado
                */
                context.Entry(usuario).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != usuario.Id)
                {
                    return this.StatusCode(StatusCodes.Status400BadRequest, "Usuario não encontrado");
                }
            }
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var user = await context.Usuarios.FindAsync(id);
                context.Usuarios.Remove(user);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, "Usuario não encontrado");
            }
        }
    }
}
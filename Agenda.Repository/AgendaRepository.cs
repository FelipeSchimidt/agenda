using System;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Repository
{
    public class AgendaRepository : IAgendaRepository
    {
        public AgendaContext context { get; }
        public AgendaRepository(AgendaContext _context)
        {
            context = _context;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }

        // USUARIOS
        public async Task<Usuario[]> GetAllUsuarioAsync(bool includeEvento = false)
        {
            IQueryable<Usuario> query = context.Usuarios
                .Include(u => u.Eventos)
                .Include(u => u.Logins);

            query = query
                .AsNoTracking()
                .OrderBy(u => u.Id);
            return await query.ToArrayAsync();
        }
        public async Task<Usuario[]> GetAllUsuarioAsyncByName(string Nome, bool includeEvento = false)
        {
            /*
            contexto do tipo IQeuryable
            que inclui os dados de Eventos e Logins
            caso existam
            */
            IQueryable<Usuario> query = context.Usuarios
                .Include(u => u.Eventos)
                .Include(u => u.Logins);

            query = query
                .AsNoTracking()
                .OrderByDescending(u => u.Nascimento)
                        .Where(u => u.Nome.Contains(Nome));
            return await query.ToArrayAsync();
        }
        public async Task<Usuario> GetUsuarioAsyncById(int UsuarioId)
        {
            /*
            contexto do tipo IQeuryable
            que inclui os dados de Eventos e Logins
            caso existam
             */
            IQueryable<Usuario> query = context.Usuarios
                .Include(u => u.Eventos)
                .Include(u => u.Logins);

            /*
            ordena a consulta segundo data de nascimento
             */
            query = query.OrderByDescending(u => u.Nascimento)
                        .Where(u => u.Id == UsuarioId);
            return await query.FirstOrDefaultAsync();
        }

        //EVENTOS
        public async Task<Evento[]> GetAllEventoAsync(bool includeUsuario = false)
        {
            IQueryable<Evento> query = context.Eventos;

            if (includeUsuario)
            {
                query = query
                    .Include(e => e.Usuario);
            }

            query = query
                .AsNoTracking()
                .OrderBy(e => e.DataEvento);
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventoByDataEvento(DateTime dataEvento, bool includeUsuario = false)
        {
            IQueryable<Evento> query = context.Eventos;

            if (includeUsuario)
            {
                query = query
                    .Include(e => e.Usuario);
            }

            query = query
                .AsNoTracking()
                .OrderByDescending(e => e.DataEvento)
                .Where(e => e.DataEvento == dataEvento);
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventoByName(string Nome, bool includeUsuario = false)
        {
            IQueryable<Evento> query = context.Eventos;

            if (includeUsuario)
            {
                query = query
                    .Include(e => e.Usuario);
            }

            query = query
                .AsNoTracking()
                .OrderBy(e => e.Nome)
                .Where(e => e.Nome.ToLower().Contains(Nome.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoById(int EventoId, bool includeUsuario = false)
        {
            IQueryable<Evento> query = context.Eventos;

            if (includeUsuario)
            {
                query = query
                    .Include(e => e.Usuario);
            }

            query = query.OrderBy(e => e.DataEvento)
                .Where(e => e.Id == EventoId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Login> GetLoginById(int LoginId, bool includeUsuario = false)
        {
            IQueryable<Login> query = context.Logins;

            if (includeUsuario)
            {
                query = query
                    .Include(e => e.Usuario);
            }

            query = query
                .AsNoTracking()
                .Where(e => e.Id == LoginId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Login> GetLoginByName(string Name, bool includeUsuario = false)
        {
            IQueryable<Login> query = context.Logins;

            if (includeUsuario)
            {
                query = query
                    .Include(e => e.Usuario);
            }

            query = query
                .AsNoTracking()
                .Where(e => e.Username.ToLower().Contains(Name.ToLower()));
            return await query.FirstOrDefaultAsync();
        }
    }
}
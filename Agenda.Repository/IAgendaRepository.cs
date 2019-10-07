using System;
using System.Threading.Tasks;
using Agenda.Domain;

namespace Agenda.Repository
{
    public interface IAgendaRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangeAsync();

        // USUARIOS
        Task<Usuario[]> GetAllUsuarioAsync(bool includeEvento);
        Task<Usuario[]> GetAllUsuarioAsyncByName(string Nome, bool includeEvento);
        Task<Usuario> GetUsuarioAsyncById(int UsuarioId);

        // EVENTOS
        Task<Evento[]> GetAllEventoAsync(bool includeUsuario);
        Task<Evento[]> GetAllEventoByDataEvento(DateTime dataEvento, bool includeUsuario);
        Task<Evento[]> GetAllEventoByName(string Nome, bool includeUsuario);
        Task<Evento> GetEventoById(int EventoId, bool includeUsuario);

        // LOGIN
        Task<Login> GetLoginById(int Id, bool includeUsuario);
        Task<Login> GetLoginByName(string nome, bool includeUsuario);
    }
}
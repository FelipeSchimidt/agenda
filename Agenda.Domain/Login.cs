using System;

namespace Agenda.Domain
{
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; }
    }
}
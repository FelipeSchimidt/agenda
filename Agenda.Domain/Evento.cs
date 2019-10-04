using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Domain
{
    public class Evento
    {
        //[Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Nome do evento obrigatório")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        //[Required(ErrorMessage = "Data do evento obrigatório")]
        public DateTime DataEvento { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
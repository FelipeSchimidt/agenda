using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspApi.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do evento obrigatório")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Data do evento obrigatório")]
        public DateTime DateEvent { get; set; }

        public IList<Agenda> Agendas { get; set; }
    }
}
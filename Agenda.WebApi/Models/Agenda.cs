using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspApi.Models
{
    public class Agenda
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o id do Usuario")]
        [ForeignKey("UsuarioId")]
        public int Users { get; set; }
        //public Usuario Usuario { get; set; }
        [Required(ErrorMessage = "Informe o id do Evento")]
        [ForeignKey("EventoId")]
        public int Events { get; set; }
        //public Evento Evento { get; set; }
        public string Observations { get; set; }
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }
    }
}
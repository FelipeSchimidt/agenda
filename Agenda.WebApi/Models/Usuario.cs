using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatorio")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime Birth { get; set; }
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Insira um endereço de email valido")]
        [Required(ErrorMessage = "Email obrigatorio")]
        public string Mail { get; set; }
        [RegularExpression(@"[a-zA-Z]")]
        public string Password { get; set; }
        public string ImagemUrl { get; set; }
        public IList<Agenda> Agendas { get; set; }
    }
}
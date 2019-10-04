using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Cpf { get; set; }
        /*         [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Insira um endereço de email valido")]
                [Required(ErrorMessage = "Email obrigatorio")] */
        public string Email { get; set; }
        public string ImagemURL { get; set; }
        public List<Evento> Eventos { get; set; }
        public List<Login> Logins { get; set; }
        //public List<Login> Login { get; set; }
    }
}
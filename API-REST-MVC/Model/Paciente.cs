using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_MVC.Model
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        //[Required(ErrorMessage = "Este campo é obrigatório")]
        //[MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        //[MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]

        public string CPF { get; set; }
        public string RG { get; set; }
        public string CNS { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string NomeMae { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }

        public List<Telefone> telefones { get; set; }

        public List<PacienteTelefone> PacientesTelefones { get; set; }

        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}

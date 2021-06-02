using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_MVC.Model
{
    public class Telefone
    {
        [Key]
        public int Id { get; set; }

        public string DDD { get; set; }

        public string Tipo { get; set; }

        public string Numero { get; set; }

        public List<PacienteTelefone> PacientesTelefones { get; set; }
    }
}

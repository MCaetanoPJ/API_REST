using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_MVC.Model
{
    public class PacienteTelefone
    {
        public int pacienteId { get; set; }

        public int telefoneId { get; set; }

        public Paciente paciente { get; set; }

        public Telefone telefone { get; set; }
    }
}

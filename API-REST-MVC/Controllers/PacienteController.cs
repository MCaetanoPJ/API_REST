using Microsoft.AspNetCore.Mvc;
using System;
using API_REST_MVC.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace API_REST_MVC.Controllers
{
    [Route("v1/Paciente")]
    [Controller]
    public class PacienteController : ControllerBase
    {
        private readonly Contexto _contexto;

        public PacienteController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET: v1/Paciente
        [Route("")]
        public ActionResult ListarPacientes()
        {
            try
            {

                var paciente = _contexto.Pacientes.ToList();
                if (paciente.Count == 0)
                {
                    return NotFound("Nenhum Paciente está cadastrado na base de dados");
                }
                else
                {
                    return Ok(paciente);
                }
                //return Ok("Listando todos os pacientes");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.StackTrace);
            }
        }

        // GET: v1/Paciente/1
        [HttpGet]
        [Route("{Id}")]
        public ActionResult ListarPacientePorId(int id)
        {
            try
            {
                var paciente = _contexto.Pacientes.FirstOrDefault(x => x.Id == id);
                if (paciente == null)
                {
                    return NotFound("O Paciente com id "+id+" não foi encontrado no banco de dados");
                }
                return Ok(paciente);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.StackTrace);
            }
        }

        // POST: v1/Paciente/ListarPacientePorNomeCPF
        [HttpPost]
        [Route("ListarPacientePorNomeCPF")]
        public ActionResult ListarPacientePorNomeCPF([FromBody] Paciente pacienteRecebido)
        {
            //try
            //{
                var paciente = _contexto.Pacientes.FirstOrDefault(x => x.Nome == pacienteRecebido.Nome || x.CPF == pacienteRecebido.CPF);
                if (paciente == null)
                {
                    string aux = "O Paciente ";
                    if (pacienteRecebido.CPF != null)
                    {
                        aux += " com CPF:"+pacienteRecebido.CPF;    
                    }
                    if (pacienteRecebido.Nome != null)
                    {
                        aux += " com Nome:" + pacienteRecebido.Nome;
                    }
                    aux += " não foi encontrado no banco de dados";

                    return NotFound(aux);
                }
                else
                {
                    return Ok(paciente);
                }
                
            /*}
            catch (Exception erro)
            {
                return BadRequest(erro.StackTrace);
            }*/
        }

        // POST: v1/Paciente/
        [HttpPost]
        [Route("")]
        public ActionResult AdicionaPaciente([FromBody] Paciente paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contexto.Add(paciente);
                    _contexto.SaveChanges();
                    //return Ok(paciente);
                    return Ok("O Paciente "+paciente.Nome+ " foi criado com sucesso!");
                }
                else
                {
                    return NotFound("Paciente não foi criado, os dados estão invalidos");
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro.StackTrace);
            }
        }

        // PUT: v1/Paciente/1
        [HttpPut]
        [Route("{id}")]
        public ActionResult EditarPaciente(int id, [FromBody] Paciente pacienteNovo, Telefone telefoneNovo)
        {
            try
            {
                if (PacienteExiste(id))
                {
                    if (ModelState.IsValid)
                    {
                        var pacienteAntigo = _contexto.Pacientes.First(x => x.Id == id);

                        //Atualizando os dados do paciente
                        pacienteAntigo.Id = pacienteNovo.Id;
                        pacienteAntigo.Nome = pacienteNovo.Nome;
                        pacienteAntigo.CPF = pacienteNovo.CPF;
                        pacienteAntigo.RG = pacienteNovo.RG;
                        pacienteAntigo.CNS = pacienteNovo.CNS;
                        pacienteAntigo.DataNascimento = pacienteNovo.DataNascimento;
                        pacienteAntigo.Sexo = pacienteNovo.Sexo;
                        pacienteAntigo.NomeMae = pacienteNovo.NomeMae;
                        pacienteAntigo.Endereco = pacienteNovo.Endereco;
                        pacienteAntigo.Bairro = pacienteNovo.Bairro;
                        pacienteAntigo.CEP = pacienteNovo.CEP;
                        pacienteAntigo.Estado = pacienteNovo.Estado;
                        pacienteAntigo.Cidade = pacienteNovo.Cidade;

                        //Atualizando os dados do telefone
                        /*var telefoneAntigo = _contexto.Telefones.First(x => x.Id == id);
                        telefoneAntigo.Id = telefoneNovo.Id;
                        telefoneAntigo.DDD = telefoneNovo.DDD;
                        telefoneAntigo.Numero = telefoneNovo.Numero;
                        telefoneAntigo.Tipo = telefoneNovo.Tipo;*/
                        
                        _contexto.SaveChanges();
                        return Ok(pacienteNovo);
                    }
                    else
                    {
                        return BadRequest("Dados inválidos");
                    }
                }
                else{
                    return NotFound("O paciente com id: "+id+" não foi encontrado no banco de dados");
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro.StackTrace);
            }
        }

        // DELETE: v1/Paciente/1
        [HttpDelete]
        [Route("{id}")]
        public ActionResult ExcluirPacientePoId(int id)
        {
            try
            {
                if (PacienteExiste(id))
                {
                    var paciente = _contexto.Pacientes.FirstOrDefault(x => x.Id == id);
                    _contexto.Remove(paciente);
                    return Ok("Paciente com " + id + "Excluído com sucesso");
                }
                else
                {
                    return NotFound("Paciente com id: "+id+ " não encontrado");
                }
                
            }
            catch (Exception erro)
            {
                return BadRequest(erro.StackTrace);
            }
        }

        private bool PacienteExiste(int id)
        {
            var paciente = _contexto.Pacientes.FirstOrDefault(x => x.Id == id);
            if (paciente != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

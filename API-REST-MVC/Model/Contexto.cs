using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_MVC.Model
{
    public class Contexto : DbContext
    {
        public DbSet<Model.Paciente> Pacientes { get; set; }
        public DbSet<Model.Telefone> Telefones { get; set; }

        public DbSet<Model.PacienteTelefone> PacientesTelefones { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacienteTelefone>(entity =>
            {
                //Informa que PacienteTelefone é composta por pacienteId e TelefoneId
                entity.HasKey(e => new { e.pacienteId, e.telefoneId });
            });
        }
    }
}

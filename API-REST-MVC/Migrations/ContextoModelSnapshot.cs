﻿// <auto-generated />
using System;
using API_REST_MVC.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_REST_MVC.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API_REST_MVC.Model.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeMae")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("API_REST_MVC.Model.PacienteTelefone", b =>
                {
                    b.Property<int>("pacienteId")
                        .HasColumnType("int");

                    b.Property<int>("telefoneId")
                        .HasColumnType("int");

                    b.HasKey("pacienteId", "telefoneId");

                    b.HasIndex("telefoneId");

                    b.ToTable("PacientesTelefones");
                });

            modelBuilder.Entity("API_REST_MVC.Model.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DDD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("API_REST_MVC.Model.PacienteTelefone", b =>
                {
                    b.HasOne("API_REST_MVC.Model.Paciente", "paciente")
                        .WithMany("PacientesTelefones")
                        .HasForeignKey("pacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_REST_MVC.Model.Telefone", "telefone")
                        .WithMany("PacientesTelefones")
                        .HasForeignKey("telefoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("paciente");

                    b.Navigation("telefone");
                });

            modelBuilder.Entity("API_REST_MVC.Model.Telefone", b =>
                {
                    b.HasOne("API_REST_MVC.Model.Paciente", null)
                        .WithMany("telefones")
                        .HasForeignKey("PacienteId");
                });

            modelBuilder.Entity("API_REST_MVC.Model.Paciente", b =>
                {
                    b.Navigation("PacientesTelefones");

                    b.Navigation("telefones");
                });

            modelBuilder.Entity("API_REST_MVC.Model.Telefone", b =>
                {
                    b.Navigation("PacientesTelefones");
                });
#pragma warning restore 612, 618
        }
    }
}

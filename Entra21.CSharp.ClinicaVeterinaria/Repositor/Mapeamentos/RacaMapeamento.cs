using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos
{
    // DB First: Criar uma aplicação
    // Code First: Cria um banco de dados apartir de uma aplicação existente
    // Seed: alimentar o banco de dados com registros
    // Migration: representação do mapeamento que sera aplicado no banco de dados
    // Mapeameno: representação da entidade em tabelas, colunas, indices....
    internal class RacaMapeamento : IEntityTypeConfiguration<Raca>
    {
        public void Configure(EntityTypeBuilder<Raca> builder)
        {
            builder.ToTable("racas");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Especie)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("especie");
            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(30)
                .IsRequired()
                .HasColumnName("nome");
        }
    }
}

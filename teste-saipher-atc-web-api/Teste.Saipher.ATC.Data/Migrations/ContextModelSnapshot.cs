﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teste.Saipher.ATC.Data.Config;

namespace Teste.Saipher.ATC.Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Teste.Saipher.ATC.Data.Entities.PlanoVoo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnName("Data_Alteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCadastro")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Data_Cadastro")
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataHoraVoo")
                        .HasColumnName("Data_Hora_Voo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnName("Destino")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<string>("MatriculaAeronave")
                        .IsRequired()
                        .HasColumnName("Matricula_Aeronave")
                        .HasColumnType("nvarchar(7)")
                        .HasMaxLength(7);

                    b.Property<string>("NumeroVoo")
                        .IsRequired()
                        .HasColumnName("Numero_voo")
                        .HasColumnType("nvarchar(7)")
                        .HasMaxLength(7);

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnName("Origem")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<string>("TipoAeronave")
                        .IsRequired()
                        .HasColumnName("Tipo_Aeronave")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("NumeroVoo")
                        .IsUnique();

                    b.ToTable("PLANO_VOO");
                });
#pragma warning restore 612, 618
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Teste.Saipher.ATC.Data.Entities;

namespace Teste.Saipher.ATC.Data.Config
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<PlanoVoo> PlanoVoo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));
        }

        private string GetConnectionString(string connectionStringName)
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            var configuration = configurationBuilder.Build();
            return configuration.GetConnectionString(connectionStringName);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanoVoo>(p =>
            {
                p.HasKey(x => x.Id);
                p.HasIndex(u => new { u.NumeroVoo }).IsUnique();
                p.Property(x => x.NumeroVoo).IsRequired(true);
                p.Property(x => x.MatriculaAeronave).IsRequired(true);
                p.Property(x => x.TipoAeronave).IsRequired(true);
                p.Property(x => x.Origem).IsRequired(true);
                p.Property(x => x.Destino).IsRequired(true);
                p.Property(x => x.DataHoraVoo).IsRequired(true);
                p.Property(x => x.DataCadastro).IsRequired(true);
                p.Property(x => x.DataCadastro).HasDefaultValueSql("GETDATE()");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
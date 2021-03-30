using Invest.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresas> Empresas { get; set;}
        public virtual DbSet<CodigoDeNegociacao> CodigoDeNegociacao { get; set;}
        public virtual DbSet<ClassificacaoSetorial> ClassificacaoSetorial { get; set;}
        public virtual DbSet<Segmento> Segmento { get; set;}
        public virtual DbSet<Setor> Setor { get; set;}
        public virtual DbSet<SubSetor> SubSetor { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

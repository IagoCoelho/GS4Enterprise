using Enterprise2._0.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Enterprise2._0.Data
{
    public class ContextNew : DbContext
    {
        public DbSet<AgendaPaciente> AgendasPacientes { get; set; }
        public DbSet<ContatosEmergencia> ContatosEmergencia { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<PlanoSaude> PlanosSaude { get; set; }
        public DbSet<UsuarioMedico> UsuariosMedicos { get; set; }
        public DbSet<UsuarioPaciente> UsuariosPacientes { get; set; }

        public ContextNew(DbContextOptions<ContextNew> options) : base(options)
        {
        }

    }
}
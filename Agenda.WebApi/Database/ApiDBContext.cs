using Microsoft.EntityFrameworkCore;
using aspApi.Models;

namespace aspApi.Database
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Agenda>()
                .HasKey(ag => new
                {
                    ag.Users,
                    ag.Events
                });

            builder.Entity<Agenda>()
                .Property(ag => ag.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Entity<Agenda>()
                .HasKey(ag => ag.Id);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
    }
}
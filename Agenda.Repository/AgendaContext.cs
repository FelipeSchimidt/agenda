using Microsoft.EntityFrameworkCore;

namespace Agenda.Domain
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /* builder.Entity<Agenda>()
                .HasKey(ag => new
                {
                    ag.Users,
                    ag.Events
                });

            builder.Entity<Agenda>()
                .Property(ag => ag.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Entity<Agenda>()
                .HasKey(ag => ag.Id) */
            ;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}
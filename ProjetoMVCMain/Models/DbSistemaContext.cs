using Microsoft.EntityFrameworkCore;

namespace ProjetoMVCMain.Models
{
    public class DbSistemaContext : DbContext
    {
        public DbSistemaContext(DbContextOptions<DbSistemaContext> options)
            : base(options)
        {
        }

        public DbSet<Consulta> Consultas { get; set; }
    }
}
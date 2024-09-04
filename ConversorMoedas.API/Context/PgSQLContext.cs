using ConversorMoedas.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConversorMoedas.API.Context
{
    public class PgSQLContext : DbContext
    {
        public PgSQLContext(DbContextOptions<PgSQLContext> options) : base(options) { }

        public DbSet<Moeda> Moedas { get; set; }
    }
}

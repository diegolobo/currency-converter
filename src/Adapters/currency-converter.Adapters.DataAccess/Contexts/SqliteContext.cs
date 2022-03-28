using currency_converter.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace currency_converter.Adapters.DataAccess.Contexts
{
    public class SqliteContext : DbContext
    {
        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
        {
        }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<Rate> Rate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Assembly assembly = this.GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}

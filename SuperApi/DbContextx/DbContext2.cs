using Microsoft.EntityFrameworkCore;
using SuperApi.Models;

namespace SuperApi.DbContextx
{
    public class DbContext2 : DbContext
    {
        public DbSet<Opis> Opisy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connectionString = "";
            builder.UseSqlServer(connectionString);
        }
    }
}

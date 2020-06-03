using Microsoft.EntityFrameworkCore;
using SuperApi.Models;

namespace SuperApi.DbContextx
{
    public class DbContext2 : DbContext
    {
        public DbSet<Opis> Opisy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=tcp:superapi20200603113044dbserver.database.windows.net,1433;Initial Catalog=SuperApi20200603113044_db;Persist Security Info=False;User ID=adminusernamexD;Password=admin123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}

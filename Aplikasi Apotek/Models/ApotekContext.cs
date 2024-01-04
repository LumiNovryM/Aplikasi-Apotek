using Microsoft.EntityFrameworkCore;

namespace Aplikasi_Apotek.Models
{
    public class ApotekContext : DbContext
    {
        public ApotekContext(DbContextOptions<ApotekContext> options) : base (options)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Barang> Barang { get; set; }
        public DbSet<Transaksi> Transaksi { get; set; }
        public DbSet<Log> Log { get; set; }
    }
}

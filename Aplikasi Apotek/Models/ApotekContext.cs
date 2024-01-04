using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Numerics;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var converter = new ValueConverter<BigInteger, long>(
                model => (long)model,
                provider => new BigInteger(provider));

            modelBuilder.Entity<Barang>()
                .Property(b => b.Harga_Satuan)
                .HasConversion(converter);

            modelBuilder.Entity<Barang>()
               .Property(b => b.Jumlah_barang)
               .HasConversion(converter);

            modelBuilder.Entity<Transaksi>()
               .Property(b => b.Total_bayar)
               .HasConversion(converter);
        }
    }
}

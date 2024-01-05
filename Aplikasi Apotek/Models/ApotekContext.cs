using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Numerics;
using System.Reflection.Emit;

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
            // Seeder
            // User
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id_user = 1,
                        Tipe_user = "Admin",
                        Nama = "Lumi",
                        Alamat = "JL Delima 1",
                        Telpon = "081288531636",
                        Username = "lumi07",
                        Password = null
                    },
                    new User
                    {
                        Id_user = 2,
                        Tipe_user = "Kasir",
                        Nama = "Novry",
                        Alamat = "JL Mangga 1",
                        Telpon = "081244542479",
                        Username = "novry11",
                        Password = null
                    },
                    new User
                    {
                        Id_user = 3,
                        Tipe_user = "Kasir",
                        Nama = "Mekel",
                        Alamat = "JL Apel 1",
                        Telpon = "089524790987",
                        Username = "mekel2005",
                        Password = null
                    }
                );

            // Barang
            modelBuilder.Entity<Barang>()
                .HasData(
                    new Barang
                    {
                        Id_barang = 1,
                        Kode_barang = "OBT",
                        Nama_barang = "Obat Tidur",
                        Expired_date = DateTime.Now,
                        Jumlah_barang = 100,
                        Satuan = "Pcs",
                        Harga_Satuan = 75000,
                    },
                    new Barang
                    {
                        Id_barang = 2,
                        Kode_barang = "OBT",
                        Nama_barang = "Obat Maag",
                        Expired_date = DateTime.Now,
                        Jumlah_barang = 50,
                        Satuan = "Pcs",
                        Harga_Satuan = 5000,
                    },
                    new Barang
                    {
                        Id_barang = 3,
                        Kode_barang = "OBT",
                        Nama_barang = "Obat Pilek",
                        Expired_date = DateTime.Now,
                        Jumlah_barang = 15,
                        Satuan = "Pcs",
                        Harga_Satuan = 25000,
                    }
                );

            // Conterter Code
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

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Aplikasi_Apotek.Models
{
    public class Barang
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto Increment
        [Required] // Membuat Field Id_user Menjadi Required
        public int Id_barang { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Kode_barang { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nama_barang { get; set; }

        [Required]
        public DateTime Expired_date { get; set; }

        [Required]
        public BigInteger Jumlah_barang { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Satuan { get; set; }

        [Required]
        public BigInteger Harga_Satuan { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Aplikasi_Apotek.Models
{
    public class Transaksi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id_transaksi { get; set; }

        [Required]
        [StringLength(50)]
        public string No_transaksi { get; set; }

        [Required]
        public DateTime Tgl_transaksi { get; set; }

        [Required]
        public BigInteger Total_bayar { get; set; }

        [Required]
        [ForeignKey("Id_user")]
        public User User { get; set; }

        [Required]
        [ForeignKey("Id_barang")]
        public Barang Barang { get; set; }

    }
}

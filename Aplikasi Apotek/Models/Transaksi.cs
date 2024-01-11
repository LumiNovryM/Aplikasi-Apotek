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
        [Column(TypeName = "varchar(50)")]
        public string No_transaksi { get; set; }

        [Required]
        public DateTime Tgl_transaksi { get; set; }

        [Required]
        public BigInteger Total_bayar { get; set; }

        [Required]
        public int Id_user { get; set; }
        [ForeignKey("Id_user")]
        public virtual User Users { get; set; }

        [Required]
        public int Id_barang { get; set; }
        [ForeignKey("Id_barang")]
        public virtual Barang Barangs { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

    }
}

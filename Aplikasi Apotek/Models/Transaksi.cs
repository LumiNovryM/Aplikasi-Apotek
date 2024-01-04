using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Aplikasi_Apotek.Models
{
    public class Transaksi
    {
        public int Id_transaksi { get; set; }
        [StringLength(50)]
        public string No_transaksi { get; set; }
        public DateTime Tgl_transaksi { get; set; }
        public BigInteger Total_bayar { get; set; }
        public int Id_user { get; set; }
        public int id_barang { get; set; }

    }
}

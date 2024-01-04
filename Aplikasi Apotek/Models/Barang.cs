using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Aplikasi_Apotek.Models
{
    public class Barang
    {
        public int Id_barang { get; set; }
        [StringLength(50)]
        public string Kode_barang { get; set; }
        [StringLength(50)]
        public string Nama_barang { get; set; }
        public DateTime Expired_date { get; set; }
        public int Jumlah_barang { get; set; }
        [StringLength(50)]
        public string Satuan { get; set; }
        public BigInteger Harga_Satuan { get;set }
    }
}

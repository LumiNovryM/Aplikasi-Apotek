using System.ComponentModel.DataAnnotations;

namespace Aplikasi_Apotek.Models
{
    public class User
    {
        public int Id_user { get; set; }
        [StringLength(50)]
        public string Tipe_user { get; set; }
        [StringLength(50)]
        public string Nama { get; set; }
        [StringLength(150)]
        public string Alamat { get; set; }
        [StringLength(50)]
        public string Telpon { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string? Password { get; set; } = null;
    }
}

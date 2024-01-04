using System.ComponentModel.DataAnnotations;

namespace Aplikasi_Apotek.Models
{
    public class Log
    {
        public int Id_log { get; set; }
        public DateTime Waktu { get; set; }
        [StringLength(50)]
        public string Aktivitas { get; set; }
        public int Id_user { get; set; }
    }
}

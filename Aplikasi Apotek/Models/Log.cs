using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplikasi_Apotek.Models
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id_log { get; set; }

        [Required]
        public DateTime Waktu { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Aktivitas { get; set; }

        [Required]
        public int Id_user { get; set; }
        [ForeignKey("Id_user")]
        public virtual User Users { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplikasi_Apotek.Models
{
    public class User
    {
        
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto Increment
        [Required] // Membuat Field Id_user Menjadi Required
        public int Id_user { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Tipe_user { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nama { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Alamat { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Telpon { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Password { get; set; } = null;
    }
}

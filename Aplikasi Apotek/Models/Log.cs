﻿using System.ComponentModel.DataAnnotations;
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
        [StringLength(50)]
        public string Aktivitas { get; set; }

        [Required]
        [ForeignKey("Id_user")]
        public User user { get; set; }
    }
}
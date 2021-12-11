using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Rent_A_Car_2021.Models
{
    public partial class Auto
    {
        private string kenteken;

        [Key, StringLength(8)]
        public string Kenteken { get => kenteken; set => kenteken = value.ToUpper(); }
        [Required , StringLength(25)]
        public string Merk { get; set; }
        [Required, StringLength(25)]
        public string Type { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Dagprijs { get; set; }
    }
}

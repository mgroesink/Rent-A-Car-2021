using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Rent_A_Car_2021.Models
{
    public partial class Factuurregel
    {

        public DateTime Begindatum { get; set; }
        public DateTime Einddatum { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Dagprijs { get; set; }

        public int Factuurnummer { get; set; }
        public Factuur Factuur { get; set; }
        public string Kenteken { get; set; }
        public Auto Auto { get; set; }

    }
}

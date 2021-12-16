using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Rent_A_Car_2021.Models
{
    public partial class Factuurregel
    {

        [DataType(DataType.Date)]
        public DateTime Begindatum { get; set; }
        [DataType(DataType.Date)] 
        public DateTime Einddatum { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        public decimal Dagprijs { get; set; }

        public int FactuurRegelID { get; set; }
        public Factuur Factuur { get; set; }
        public Auto Auto { get; set; }

    }
}

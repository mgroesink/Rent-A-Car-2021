using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Rent_A_Car_2021.Models
{
    public partial class Factuur
    {
        [Key]
        public int Factuurnummer { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        public virtual Klant Klant { get; set; }
        public virtual Medewerker Medewerker { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car_2021.Models.ViewModels
{
    public class ReserveerVM
    {
        public Auto Auto { get; set; }
        [DataType(DataType.Date)]
        public DateTime Van { get; set; }
        [Range(1,10)]
        public int AantalDagen { get; set; }
    }
}

using Rent_A_Car_2021.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car_2021.Models.ViewModels
{
    public class ReserveerVM
    {
        public string Kenteken { get; set; }
        [DataType(DataType.Date)]
        public DateTime Van { get; set; } = DateTime.Now.AddDays(1);
        [Range(1, 10)]
        public int AantalDagen { get; set; } = 1;
        public string Merk { get; set; }
        public string Type { get; set; }
        public decimal Dagprijs { get; set; }
        //public List<Auto> AvailableCars { get; set; }

        //public ReserveerVM(ApplicationDbContext db)
        //{
        //    _db = db;
        //    AvailableCars = _db.Autos.ToList();

        //}
        public ReserveerVM()
        {
        }
    }
}

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
        private readonly ApplicationDbContext _db;
        public string Kenteken { get; set; }
        [DataType(DataType.Date)]
        public DateTime Van { get; set; }
        [Range(1,10)]
        public int AantalDagen { get; set; }
        public List<Auto> AvailableCars { get; set; }

        public ReserveerVM(ApplicationDbContext db)
        {
            _db = db;
            AvailableCars = _db.Autos.ToList();

        }
        public ReserveerVM()
        {
            AvailableCars = _db.Autos.ToList();
        }
    }
}

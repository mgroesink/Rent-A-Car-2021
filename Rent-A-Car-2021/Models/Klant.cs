using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Rent_A_Car_2021.Models
{
    public partial class Klant
    {
        public Klant()
        {
            Facturen = new HashSet<Factuur>();
        }
        [Key , StringLength(6)]
        [Column(TypeName = "char")]
        public string Klantcode { get; set; }
        [Required, StringLength(10)]
        public string Voorletters { get; set; }
        [StringLength(15)]
        public string Tussenvoegsels { get; set; }
        [Required, StringLength(50)]
        public string Achternaam { get; set; }
        [StringLength(75)]
        public string Adres { get; set; }
        [StringLength(6)]
        [Column(TypeName = "char")]
        public string Postcode { get; set; }
        [StringLength(75)]
        public string Woonplaats { get; set; }


        public virtual ICollection<Factuur> Facturen { get; set; }
        public virtual IdentityUser AspNetUserNavigation { get; set; }

    }
}

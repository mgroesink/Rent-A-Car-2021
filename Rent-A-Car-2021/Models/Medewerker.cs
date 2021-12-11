using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Rent_A_Car_2021.Models
{
    public partial class Medewerker
    {
        public Medewerker()
        {
            Facturen = new HashSet<Factuur>();
        }

        [Key , StringLength(5)]
        [Column(TypeName = "char")]
        public string Medewerkerscode { get; set; }
        [Required , StringLength(25)]
        public string Voornaam { get; set; }
        [StringLength(15)]
        public string Tussenvoegsels { get; set; }
        [Required , StringLength(50)] 
        public string Achternaam { get; set; }

        public virtual ICollection<Factuur> Facturen { get; set; }
        public virtual IdentityUser AspNetUserNavigation { get; set; }
    }
}

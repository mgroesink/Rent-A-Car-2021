using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car_2021.Models.ViewModels
{
    public class RegisterEmployee
    {
        [Key, StringLength(5)]
        [Column(TypeName = "char")]
        public string Medewerkerscode { get; set; }
        [Required, StringLength(25)]
        public string Voornaam { get; set; }
        [StringLength(15)]
        public string Tussenvoegsels { get; set; }
        [Required, StringLength(50)]
        public string Achternaam { get; set; }
        //
        // Summary:
        //     This API supports the ASP.NET Core Identity default UI infrastructure and is
        //     not intended to be used directly from your code. This API may change or be removed
        //     in future releases.
        [Display(Name = "E-mail")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        //
        // Summary:
        //     This API supports the ASP.NET Core Identity default UI infrastructure and is
        //     not intended to be used directly from your code. This API may change or be removed
        //     in future releases.
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        [Required]
        [StringLength(100, ErrorMessage = "Het {0} moet tenminste {2} en maximaal {1} teken bevatten.", MinimumLength = 6)]
        public string Wachtwoord { get; set; }
        //
        // Summary:
        //     This API supports the ASP.NET Core Identity default UI infrastructure and is
        //     not intended to be used directly from your code. This API may change or be removed
        //     in future releases.
        [Compare("Wachtwoord", ErrorMessage = "De wachtwoorden komen niet overeen.")]
        [DataType(DataType.Password)]
        [Display(Name = "Bevestig wachtwoord")]
        public string Wachtwoord2 { get; set; }

    }
}
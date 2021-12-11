using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car_2021.Models.ViewModels
{
    public class RegisterCustomer: RegisterModel
    {
        public string Voorletters { get; set; }
        public string Tussenvoegsels { get; set; }
        public string Achternaam { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
        public string Klantcode { get; set; }

    }
}

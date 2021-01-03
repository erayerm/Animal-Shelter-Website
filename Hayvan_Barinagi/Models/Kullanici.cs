using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hayvan_Barinagi.Models
{
    public class Kullanici : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hayvan_Barinagi.Models
{
    public class Hayvan
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int? DogumYili { get; set; }
        public string Hakkinda { get; set; }
        public string Fotograf { get; set; }
        public int TurID { get; set; }
        public Tur Tur { get; set; }
        public int CinsID { get; set; }
        public Cins Cins { get; set; }
        public int CinsiyetID { get; set; }
        public Cinsiyet Cinsiyet { get; set; }

    }
}

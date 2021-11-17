using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Nakup
    {
        public int NakupID { get; set; }
        public DateTime DatumNakupa { get; set; }
        public string Cena { get; set; }

        //one
        [ForeignKey("Uporabnik")]
        public string UporabnikID { get; set; }
        public Uporabnik Uporabnik { get; set; }

        //many
        public ICollection<GradivoIzvod> GradivoIzvodi { get; set; }
    }
}
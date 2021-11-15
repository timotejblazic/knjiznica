using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Nakup
    {
        public int NakupID { get; set; }
        public DateTime DatumNakupa { get; set; }
        public string Cena { get; set; }

        //one
        public Uporabnik Uporabnik { get; set; }

        //many
        public ICollection<GradivoIzvod> GradivoIzvodi { get; set; }
    }
}
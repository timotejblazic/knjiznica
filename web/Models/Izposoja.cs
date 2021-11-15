using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Izposoja
    {
        public int IzposojaID { get; set; }
        public DateTime DatumIzposoje { get; set; }
        public DateTime DatumVrnitve { get; set; } 
        
        //one
        public Uporabnik Uporabnik { get; set; }

        //many
        public ICollection<GradivoIzvod> GradivoIzvodi { get; set; }
    }
}
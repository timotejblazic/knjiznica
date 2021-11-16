using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Gradivo
    {
        public int GradivoID { get; set; }
        public string Naslov { get; set; }
        public int LetoIzdaje { get; set; }
        public int SteviloStrani { get; set; }
        public string Opis { get; set; }

        //one
        public int KategorijaID { get; set; }
        public Kategorija Kategorija { get; set; }
        public int ZanrID { get; set; }
        public Zanr Zanr { get; set; }
        public int ZalozbaID { get; set; }
        public Zalozba Zalozba { get; set; }

        //many
        public ICollection<Avtor>? Avtorji { get; set; }
        public ICollection<GradivoIzvod>? GradivoIzvodi { get; set; }
        public ICollection<Ocena>? Ocene { get; set; }
    }
}
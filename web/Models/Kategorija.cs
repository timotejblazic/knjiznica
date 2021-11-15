using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Kategorija
    {
        public int KategorijaID { get; set; }
        public string Naziv { get; set; }   // knjiga, strip, revija, film,...

        public ICollection<Gradivo>? Gradiva { get; set; }
    }
}
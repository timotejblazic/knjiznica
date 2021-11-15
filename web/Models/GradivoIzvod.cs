using System;
using System.Collections.Generic;

namespace web.Models
{
    public class GradivoIzvod
    {
        public int GradivoIzvodID { get; set; }

        //one
        public Gradivo Gradivo { get; set; }
        public Izposoja? Izposoja { get; set; }
        public Nakup? Nakup { get; set; }
    
    }
}
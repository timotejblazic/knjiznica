using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public enum Vrednost
    {
        A, B, C, D, F
    }

    public class Ocena
    {
        public int OcenaID { get; set; }
        public Vrednost Vrednost { get; set; }    // 1,2,3,4,5
        public string? Mnenje { get; set; }

        //one
        [ForeignKey("Uporabnik")]
        public string UporabnikID { get; set; }
        public Uporabnik Uporabnik { get; set; }
        [ForeignKey("Gradivo")]
        public int GradivoID { get; set; }
        public Gradivo Gradivo { get; set; }
    }
}
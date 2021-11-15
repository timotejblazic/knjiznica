using System;
using System.Collections.Generic;

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
        public Uporabnik Uporabnik { get; set; }
        public Gradivo Gradivo { get; set; }
    }
}
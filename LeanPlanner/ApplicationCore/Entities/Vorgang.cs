using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Vorgang : BaseEntity
    {
        public int ProjektId { get; set; }
        public Projekt Projekt { get; set; }
        public string Zug { get; set; }
        public DateTime Anfang { get; set; }
        public DateTime Ende { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Projekt : BaseEntity
    {
        public string Bezeichnung { get; set; }
        public string Kostenstelle { get; set; }
        public string Adresse { get; set; }
        public string Status { get; set; }
        public ICollection<Vorgang> Vorgänge { get; set; }
    }
}

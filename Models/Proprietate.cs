using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectWeb.Models
{
    public class Proprietate
    {
        public int ID { get; set; }
        public string Tip_oferta { get; set; }
        public string Zona { get; set; }
        public int Nr_camere { get; set; }
        public int Suprafata { get; set; }
        public string Amplasament { get; set; }
        public string Adresa { get; set; }

        public ICollection<Factura> Facturi { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectWeb.Models
{
    public class Foodtruck
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        //Mare, Mediu, Mic
        public string Tip { get; set; }
        //Central, Urban, Rural
        public string Adresa { get; set; }

        public ICollection<Comanda> Comenzi { get; set; }

    }
}

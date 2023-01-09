using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectWeb.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Nr_tel { get; set; }
        public string Email { get; set; }
        public ICollection<Factura> Facturi { get; set; }
    }
}

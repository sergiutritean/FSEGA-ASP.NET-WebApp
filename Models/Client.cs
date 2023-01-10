using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectWeb.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string NrTel { get; set; }
        public string Email { get; set; }
        public ICollection<Comanda> Comenzi { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProiectWeb.Models
{
    public class Factura
    {
        public int ID { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal suma { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public int ContactID { get; set; }
        public Contact Contact { get; set; }
        public int ProprietateID { get; set; }
        public Proprietate Proprietate { get; set; }

    }
}

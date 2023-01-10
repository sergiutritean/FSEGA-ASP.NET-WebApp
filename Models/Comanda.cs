using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProiectWeb.Models
{
    public class Comanda
    {
        public int ID { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Suma { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public int ClientID { get; set; }
        public string Descriere { get; set; }
        public Client Client { get; set; }
        public int FoodtruckID { get; set; }
        public Foodtruck Foodtruck { get; set; }

    }
}

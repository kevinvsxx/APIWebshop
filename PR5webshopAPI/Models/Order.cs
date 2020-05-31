using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PR5webshopAPI.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        public string Orderdate { get; set; }

        public int CustomerID { get; set; }

        public int ProductID { get; set; }

        public int Amount { get; set; }

        public double Total { get; set; }
    }
}

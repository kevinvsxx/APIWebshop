using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PR5webshopAPI.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public int CategoryID { get; set; }

        public string ImgUrl { get; set; }

        public double Price { get; set; }
    }
}

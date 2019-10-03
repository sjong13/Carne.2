using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carne.Web.Models
{
    public class Meat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string URI { get; set; }
        
    }
}
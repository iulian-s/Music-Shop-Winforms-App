using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPAOO.Models
{
    internal class Instruments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }

    }
}
